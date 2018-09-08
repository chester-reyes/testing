using StockDividendDownloader.Contract.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace StockDividendDownloader.Contract.Messages
{
    [DataContract]
    public class GetStockDataResponse : Response
    {
        [DataMember]
        public IEnumerable<StockData> StockList { get; set; }
    }
}
