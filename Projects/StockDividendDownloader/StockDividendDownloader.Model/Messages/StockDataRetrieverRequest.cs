using StockDividendDownloader.Shared.Types;
using System.Collections.Generic;

namespace StockDividendDownloader.Contract.Messages
{
    public class StockDataRetrieverRequest : Request
    {
        public IEnumerable<string> StockList { get; set; }

        public static explicit operator StockDataRetrieverRequest(Contract.Messages.GetStockDataRequest request)
        {
            if (request == null)
                return null;

            return new StockDataRetrieverRequest
            {
                CorrelationID = request.CorrelationID,
                StockList = request.StockList
            };
        }
    }
}
