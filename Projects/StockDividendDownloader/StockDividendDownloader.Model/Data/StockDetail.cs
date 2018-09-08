using System;

namespace StockDividendDownloader.Model.Data
{
    public class StockDetail
    {
        public DateTime DateTime { get; set; }
        public StockPrice StockPrice { get; set; }
        public int Volume { get; set; }
    }
}
