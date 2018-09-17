using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using StockDividendDownloader.Logic.Extensions;
using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Model.Interfaces;
using StockDividendDownloader.Model.Messages;

namespace StockDividendDownloader.Logic
{
    public class StockDividendDataRetriever : IStockDividendDataRetriever
    {
        private readonly IConfiguration _configuration;
        public StockDividendDataRetriever(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<StockDividendRetrieverResponse> Retrieve(StockDividendRetrieverRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var client = new RestClient(_configuration["NASDAQ:HostURL"]);
                    var restRequest = new RestRequest(string.Format(_configuration["NASDAQ:DividendResource"], request.StockSymbol), Method.GET);

                    var response = client.ExecuteAsync(restRequest).Result;
                    var doc = new HtmlDocument();
                    doc.LoadHtml(response.Content);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                        {
                            return new StockDividendRetrieverResponse
                            {
                                CorrelationID = request.CorrelationID,
                                CallStatus = Shared.Types.CallStatus.Failed,
                                Error = new Shared.Types.Error { Exception = response.ErrorException }
                            };
                        }
                    }

                    var dividendDetails = new List<DividendDetail>();
                    var dividendTable = doc.DocumentNode.SelectSingleNode("//table[@id='quotes_content_left_dividendhistoryGrid']");
                    if (dividendTable != null)
                    {
                        var tRows = dividendTable.SelectNodes("//tbody/tr");
                        if (tRows != null)
                        {
                            var innerHtmls = tRows.Select(x => x.InnerHtml).ToList();

                            foreach (var innerHtml in innerHtmls)
                            {
                                var doc2 = new HtmlDocument();
                                doc2.LoadHtml(innerHtml);

                                var tSpan = doc2.DocumentNode.SelectNodes("//span");
                                if (tSpan != null && tSpan.Count == 5)
                                {
                                    dividendDetails.Add(new DividendDetail
                                    {
                                        ExDate = tSpan[0].InnerText,
                                        CashAmount = tSpan[1].InnerText,
                                        DeclarationDate = tSpan[2].InnerText,
                                        RecordDate = tSpan[3].InnerText,
                                        PaymentDate = tSpan[4].InnerText
                                    });
                                }

                                if ( request.DividendHistory.Equals("CURRENT") )
                                {
                                    return new StockDividendRetrieverResponse
                                    {
                                        CorrelationID = request.CorrelationID,
                                        CallStatus = Shared.Types.CallStatus.Succeeded,
                                        DividendDetails = dividendDetails
                                    };
                                }
                            }
                        }
                    }

                    return new StockDividendRetrieverResponse
                    {
                        CorrelationID = request.CorrelationID,
                        CallStatus = Shared.Types.CallStatus.Succeeded,
                        DividendDetails = dividendDetails
                    };
                }
                catch (Exception ex)
                {
                    return new StockDividendRetrieverResponse
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
