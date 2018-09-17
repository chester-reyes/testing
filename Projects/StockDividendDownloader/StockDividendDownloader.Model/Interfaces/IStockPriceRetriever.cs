using StockDividendDownloader.Model.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockDividendDownloader.Model.Interfaces
{
    public interface IStockPriceRetriever
    {
        Task<StockPriceRetrieverResponse> Retrieve(StockPriceRetrieverRequest request);
    }
}
