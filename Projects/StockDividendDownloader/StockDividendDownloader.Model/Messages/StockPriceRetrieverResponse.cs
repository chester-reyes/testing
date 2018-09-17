using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Model.Messages
{
    public class StockPriceRetrieverResponse : Response
    {
        public string StockSymbol { get; set; }
        public IEnumerable<StockDetail> StockDetails { get; set; }
    }
}
