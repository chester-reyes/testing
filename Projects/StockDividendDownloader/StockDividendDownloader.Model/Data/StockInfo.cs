using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Model.Data
{
    public class StockInfo
    {
        public string StockSymbol { get; set; }
        public IEnumerable<DividendDetail> DividendDetails { get; set; }
    }
}
