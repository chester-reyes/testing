using System;
using System.Runtime.Serialization;

namespace StockDividendDownloader.Shared.Types
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string CorrelationID { get; set; }
        [DataMember]
        public CallStatus CallStatus { get; set; }
        [DataMember]
        public Error Error { get; set; }
    }
}
