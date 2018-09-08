using System;
using System.Threading.Tasks;
using StockDividendDownloader.Model.Messages;

namespace StockDividendDownloader.Model.Interfaces
{
    public interface IStockDividendDataRetriever
    {
        Task<StockDividendDataRetrieverResponse> Retrieve(StockDividendDataRetrieverRequest request);
    }
}
