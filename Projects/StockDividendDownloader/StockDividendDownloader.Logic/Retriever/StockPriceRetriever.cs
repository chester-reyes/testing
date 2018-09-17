using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using StockDividendDownloader.Logic.Extensions;
using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Model.Interfaces;
using StockDividendDownloader.Model.Messages;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockDividendDownloader.Logic.Retriever
{
    public class StockPriceRetriever : IStockPriceRetriever
    {
        private readonly IConfiguration _configuration;
        public StockPriceRetriever(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<StockPriceRetrieverResponse> Retrieve(StockPriceRetrieverRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var client = new RestClient(_configuration["NASDAQ:HostURL"]);
                    var restRequest = new RestRequest(string.Format(_configuration["NASDAQ:StockPriceResource"], request.StockSymbol), Method.GET);

                    var response = client.ExecuteAsync(restRequest).Result;
                    var doc = new HtmlDocument();
                    doc.LoadHtml(response.Content);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                        {
                            return new StockPriceRetrieverResponse
                            {
                                CorrelationID = request.CorrelationID,
                                CallStatus = Shared.Types.CallStatus.Failed,
                                Error = new Shared.Types.Error { Exception = response.ErrorException }
                            };
                        }
                    }

                    var dividendTable = doc.DocumentNode.SelectSingleNode("//div[@class='table-table fontS14px']");
                    var tRows = dividendTable.SelectNodes("//div[@class='table-row']");
                    var stockPrice = new StockPrice();

                    var priceDiv = doc.DocumentNode.SelectSingleNode("//div[@id='qwidget_lastsale']");//.InnerText.Replace("$", string.Empty).Trim();
                    stockPrice.CurrentPrice = priceDiv.InnerText.Replace("$", string.Empty);

                    foreach (var tRow in tRows)
                    {
                        if ( tRow.InnerText.Contains("Share Volume") )
                            stockPrice.Volume = stockPrice.Volume ?? WebUtility.HtmlDecode(tRow.InnerText.Split("\n")[5]).Replace("$",string.Empty).Trim();

                        if (tRow.InnerText.Contains("Today's High"))
                        {
                            stockPrice.TodayHigh = WebUtility.HtmlDecode(tRow.InnerText).Split("\n")[5].Trim().Split("/")[0].Remove(0, 2);
                            stockPrice.TodayLow = WebUtility.HtmlDecode(tRow.InnerText).Split("\n")[5].Trim().Split("/")[1].Remove(0, 2);
                        }

                        if (tRow.InnerText.Contains("52 Week"))
                        {
                            stockPrice.YearWeekHigh = WebUtility.HtmlDecode(tRow.InnerText).Split("\n")[5].Trim().Split("/")[0].Remove(0, 2);
                            stockPrice.YearWeekLow = WebUtility.HtmlDecode(tRow.InnerText).Split("\n")[5].Trim().Split("/")[1].Remove(0, 2);
                        }

                        if (tRow.InnerText.Contains("P/E Ratio"))
                            stockPrice.PERatio = stockPrice.PERatio ?? WebUtility.HtmlDecode(tRow.InnerText.Split("\n")[5]).Replace("$", string.Empty).Trim();

                        if (tRow.InnerText.Contains("Previous Close"))
                            stockPrice.PreviousClose = WebUtility.HtmlDecode(tRow.InnerText).Split("\n")[5].Trim().Remove(0, 2);
                    }

                    return new StockPriceRetrieverResponse
                    {
                        CorrelationID = request.CorrelationID,
                        CallStatus = Shared.Types.CallStatus.Succeeded,
                        StockDetails = new List<StockDetail>
                        {
                           new StockDetail
                           {
                               StockPrice = stockPrice
                           }
                        }
                    };
                }
                catch (Exception ex)
                {
                    return new StockPriceRetrieverResponse
                    {
                        CorrelationID = request.CorrelationID,
                        CallStatus = Shared.Types.CallStatus.Failed,
                        Error = new Shared.Types.Error { Exception = ex, Message = ex.Message }
                    };
                }
            });

        }
    }
}
