using System;
using System.Threading.Tasks;
using StockDividendDownloader.Model.Interfaces;
using StockDividendDownloader.Model.Messages;

namespace StockDividendDownloader.Logic
{
    public class StockDividendDataRetriever : IStockDividendDataRetriever
    {
        public StockDividendDataRetriever()
        {
        }

        public Task<StockDividendDataRetrieverResponse> Retrieve(StockDividendDataRetrieverRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
