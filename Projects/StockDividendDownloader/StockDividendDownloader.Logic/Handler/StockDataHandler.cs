using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Model.Interfaces;
using StockDividendDownloader.Model.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockDividendDownloader.Logic.Handler
{
    public class StockDataHandler : IStockDataHandler
    {
        private readonly IStockPriceRetriever _stockPriceRetriever;
        private readonly IStockDividendDataRetriever _stockDividendDataRetriever;

        public StockDataHandler(IStockPriceRetriever stockPriceRetriever, IStockDividendDataRetriever stockDividendDataRetriever)
        {
            _stockDividendDataRetriever = stockDividendDataRetriever;
            _stockPriceRetriever = stockPriceRetriever;
        }

        public async Task<GetStockDataHandlerResponse> Handle(GetStockDataHandlerRequest request)
        {
            try
            {
                if ( request == null)
                {
                    return new GetStockDataHandlerResponse
                    {
                        CorrelationID = request.CorrelationID,
                        CallStatus = Shared.Types.CallStatus.Failed,
                        Error = new Shared.Types.Error { Exception = new ArgumentNullException() }
                    };
                }

                var StockList = new List<StockData>();
                foreach (var stock in request.StockList)
                {
                    var stockPriceRetrieverResponse = _stockPriceRetriever.Retrieve(new StockPriceRetrieverRequest
                    {
                        CorrelationID = request.CorrelationID,
                        PriceHistory = request.PriceHistory,
                        StockSymbol = stock
                    }).Result;

                    var stockDividendRetrieverResponse = _stockDividendDataRetriever.Retrieve(new StockDividendRetrieverRequest
                    {
                        CorrelationID = request.CorrelationID,
                        StockSymbol = stock,
                        DividendHistory = request.DividendHistory
                    }).Result;

                    StockList.Add(new StockData
                    {
                        StockSymbol = stock,
                        DividendDetails = stockDividendRetrieverResponse?.DividendDetails,
                        StockDetails = stockPriceRetrieverResponse?.StockDetails
                    });
                }

                return new GetStockDataHandlerResponse
                {
                    CallStatus = Shared.Types.CallStatus.Succeeded,
                    CorrelationID = request.CorrelationID,
                    StockList = StockList
                };
            }
            catch (Exception ex)
            {
                return new GetStockDataHandlerResponse
                {
                    CallStatus = Shared.Types.CallStatus.Failed,
                    CorrelationID = request.CorrelationID,
                    Error = new Shared.Types.Error { Exception = ex }
                };
            }
        }
    }
}
