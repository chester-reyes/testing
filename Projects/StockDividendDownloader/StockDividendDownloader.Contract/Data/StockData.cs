using System;
using System.Collections.Generic;

namespace StockDividendDownloader.Contract.Data
{
    public class StockData
    {
        public string StockSymbol { get; set; }
        public IEnumerable<StockDetail> StockDetails { get; set; }
        public IEnumerable<DividendDetail> DividendDetails { get; set; }
    }
}
