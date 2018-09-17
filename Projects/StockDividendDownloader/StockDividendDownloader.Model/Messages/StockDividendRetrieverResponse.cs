using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StockDividendDownloader.Model.Messages
{
    public class StockDividendRetrieverResponse : Response
    {
        public string StockSymbol { get; set; }
        public IEnumerable<DividendDetail> DividendDetails { get; set; }
    }
}
