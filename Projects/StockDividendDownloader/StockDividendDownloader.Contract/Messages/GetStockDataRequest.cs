using StockDividendDownloader.Shared.Types;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StockDividendDownloader.Contract.Messages
{
    [DataContract]
    public class GetStockDataRequest : Request
    {
        [DataMember]
        public IEnumerable<string> StockList { get; set; }
        [DataMember]
        public string DividendHistory { get; set; }
        [DataMember]
        public string PriceHistory { get; set; }
    }
}
