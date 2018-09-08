using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<StockDividendDataRetrieverResponse> Retrieve(StockDividendDataRetrieverRequest request)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var client = new RestClient(_configuration["StockAPI:HostURL"]);
                    var StockDetails = new List<StockInfo>();
                    foreach (var stock in request.StockList)
                    {
                        var restRequest = new RestRequest(string.Format(_configuration["StockAPI:Resources"], stock, request.NumOfYears), Method.GET);
                        var response = client.ExecuteAsync(restRequest).Result;

                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                        {
                            return new StockDividendDataRetrieverResponse
                            {
                                CorrelationID = request.CorrelationID,
                                CallStatus = Shared.Types.CallStatus.Failed,
                                Error = new Shared.Types.Error { Exception = response.ErrorException }
                            };
                        }

                        var dividendData = JsonConvert.DeserializeObject<IEnumerable<DividendDetail>>(response.Content);
                        StockDetails.Add(new StockInfo
                        {
                            StockSymbol = stock,
                            DividendDetails = dividendData
                        });
                    }

                    return new StockDividendDataRetrieverResponse
                    {
                        CorrelationID = request.CorrelationID,
                        CallStatus = Shared.Types.CallStatus.Succeeded,
                        StockDetails = StockDetails
                    };

                }
                catch (Exception ex)
                {
                    return new StockDividendDataRetrieverResponse
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
