using System;
using System.Runtime.Serialization;

namespace StockDividendDownloader.Shared.Types
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public string CorrelationID { get; set; }
    }
}
