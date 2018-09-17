using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDividendDownloader.Model.Messages
{
    public class GetStockDataHandlerRequest : Request
    {
        public IEnumerable<string> StockList { get; set; }
        public string DividendHistory { get; set; }
        public string PriceHistory { get; set; }

        public static explicit operator GetStockDataHandlerRequest(Contract.Messages.GetStockDataRequest request)
        {
            if (request == null)
                return null;

            return new GetStockDataHandlerRequest
            {
                CorrelationID = request.CorrelationID,
                StockList = request.StockList.ToList(),
                DividendHistory = request.DividendHistory,
                PriceHistory = request.PriceHistory
            };
        }
    }
}
