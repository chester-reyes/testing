using StockDividendDownloader.Shared.Types;
using System.Collections.Generic;

namespace StockDividendDownloader.Model.Messages
{
    public class StockDividendRetrieverRequest : Request
    {
        public string StockSymbol { get; set; }
        public string DividendHistory { get; set; }
    }
}
