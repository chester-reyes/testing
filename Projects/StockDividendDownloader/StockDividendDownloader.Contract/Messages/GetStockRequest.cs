using StockDividendDownloader.Shared.Types;

namespace StockDividendDownloader.Contract.Messages
{
    public class GetStockRequest : Request
    {
        public string StockSymbol { get; set; }
    }
}
