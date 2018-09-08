using StockDividendDownloader.Contract.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StockDividendDownloader.Contract.Messages
{
    [DataContract]
    public class GetStockResponse : Response
    {
        [DataMember]
        public string StockSymbol { get; set; }
        [DataMember]
        public IEnumerable<StockDetail> StockDetails { get; set; }
        [DataMember]
        public IEnumerable<DividendDetail> DividendDetails { get; set; }
        [DataMember]
        public DateTime LastRefreshed { get; set; }
    }
}
