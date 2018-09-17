using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Model.Messages
{
    public class StockPriceRetrieverRequest : Request
    {
        public string StockSymbol { get; set; }
        public string PriceHistory { get; set; }
    }
}
