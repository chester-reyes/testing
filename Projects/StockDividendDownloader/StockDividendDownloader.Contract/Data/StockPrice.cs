using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Contract.Data
{
    public class StockPrice
    {
        public int Open { get; set; }
        public int High { get; set; }
        public int Low { get; set; }
        public int Close { get; set; }
    }
}
