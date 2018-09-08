using System;
using System.Collections.Generic;

namespace StockDividendDownloader.Model.Data
{
    public class StockData
    {
        public string StockSymbol { get; set; }
        public IEnumerable<StockDetail> StockDetails { get; set; }
        public DateTime LastRefreshed { get; set; }
    }
}
