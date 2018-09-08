using System;
namespace StockDividendDownloader.Shared.Types
{
    public class Response
    {
        public string CorrelationID { get; set; }
        public CallStatus CallStatus { get; set; }
        public Error Error { get; set; }
    }
}
