using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Model.Data
{
    public class StockPrice
    {
        public string CurrentPrice { get; set; }
        public string TodayHigh { get; set; }
        public string TodayLow { get; set; }
        public string YearWeekHigh { get; set; }
        public string YearWeekLow { get; set; }
        public string PreviousClose { get; set; }
        public string PERatio { get; set; }
        public string Volume { get; set; }
    }
}
