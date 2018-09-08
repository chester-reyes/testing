using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using StockDividendDownloader.Contract.Data;
using StockDividendDownloader.Shared.Types;

namespace StockDividendDownloader.Contract.Messages
{
    [DataContract]
    public class GetStockDividendDataResponse : Response
    {
        [DataMember]
        public IEnumerable<StockInfo> StockDetails { get; set; }
    }
}
