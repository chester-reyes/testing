using System;
namespace StockDividendDownloader.Shared.Types
{
    public class Error
    {
        public string Code { get; set; }
        public Exception Exception { get; set; }
        public string Message { get; set; }
    }
}
