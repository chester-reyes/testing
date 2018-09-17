using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Contract.Data
{
    public class StockPrice
    {
        [JsonProperty(PropertyName = "Current Price")]
        public string CurrentPrice { get; set; }
        [JsonProperty(PropertyName = "Today's High")]
        public string TodayHigh { get; set; }
        [JsonProperty(PropertyName = "Today's Low")]
        public string TodayLow { get; set; }
        [JsonProperty(PropertyName = "52 Week High")]
        public string YearWeekHigh { get; set; }
        [JsonProperty(PropertyName = "52 Week Low")]
        public string YearWeekLow { get; set; }
        [JsonProperty(PropertyName = "Previous Close")]
        public string PreviousClose { get; set; }
        [JsonProperty(PropertyName = "P/E Ratio")]
        public string PERatio { get; set; }
        [JsonProperty(PropertyName = "Volume")]
        public string Volume { get; set; }
    }
}
