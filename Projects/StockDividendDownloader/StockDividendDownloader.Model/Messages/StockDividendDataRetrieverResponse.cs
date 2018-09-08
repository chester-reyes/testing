using System;
using System.Collections.Generic;
using System.Linq;
using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Shared.Types;

namespace StockDividendDownloader.Model.Messages
{
    public class StockDividendDataRetrieverResponse : Response
    {
        public IEnumerable<StockInfo> StockDetails { get; set; }

        public static explicit operator Contract.Messages.GetStockDividendDataResponse(StockDividendDataRetrieverResponse response)
        {
            if (response == null)
                return null;

            return new Contract.Messages.GetStockDividendDataResponse
            {
                CorrelationID = response.CorrelationID,
                CallStatus = response.CallStatus,
                Error = response.Error,
                StockDetails = response.StockDetails.ToList().Select(x => new Contract.Data.StockInfo
                {
                    StockSymbol = x.StockSymbol,
                    DividendDetails = x.DividendDetails.Select(y => new Contract.Data.DividendDetail
                    {
                        amount = y.amount,
                        declaredDate = y.declaredDate,
                        exDate = y.exDate,
                        flag = y.flag,
                        indicated = y.indicated,
                        paymentDate = y.paymentDate,
                        qualified = y.qualified,
                        recordDate = y.recordDate,
                        type = y.type
                    }).ToList()
                }).ToList()
            };
        }
    }
}
