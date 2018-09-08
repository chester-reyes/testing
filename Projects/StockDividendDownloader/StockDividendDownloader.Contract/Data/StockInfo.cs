using System.Collections.Generic;

namespace StockDividendDownloader.Contract.Data
{
    public class StockInfo
    {
        public string StockSymbol { get; set; }
        public IEnumerable<DividendDetail> DividendDetails { get; set; }
    }
}
