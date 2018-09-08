using Newtonsoft.Json;
using StockDividendDownloader.Shared.Types;
using System.Collections.Generic;

namespace StockDividendDownloader.Model.Messages
{
    [JsonObject(MemberSerialization.OptOut)]
    public class StockDividendDataRetrieverRequest : Request
    {
        public IEnumerable<string> StockList { get; set; }
        public int NumOfYears { get; set; }

        public static explicit operator StockDividendDataRetrieverRequest (Contract.Messages.GetStockDividendDataRequest request)
        {
            if (request == null)
                return null;

            return new StockDividendDataRetrieverRequest
            {
                CorrelationID = request.CorrelationID,
                StockList = request.StockList,
                NumOfYears = request.NumOfYears
            };
        }
    }
}
