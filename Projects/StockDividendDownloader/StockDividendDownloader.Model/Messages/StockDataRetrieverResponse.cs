using StockDividendDownloader.Contract.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace StockDividendDownloader.Contract.Messages
{
    public class StockDataRetrieverResponse : Response
    {
        public IEnumerable<StockData> StockList { get; set; }

        public static explicit operator Contract.Messages.GetStockDataResponse(StockDataRetrieverResponse response)
        {
            if (response == null)
                return null;

            return new GetStockDataResponse
            {
                CorrelationID = response.CorrelationID,
                CallStatus = response.CallStatus,
                Error = response.Error,
                StockList = response.StockList.ToList().Select(x => new StockData
                {
                    LastRefreshed = x.LastRefreshed,
                    StockDetails = x.StockDetails.Select(y => new StockDetail
                    {
                        DateTime = y.DateTime,
                        StockPrice = new StockPrice
                        {
                            Close = y.StockPrice.Close,
                            High = y.StockPrice.High,
                            Low = y.StockPrice.Low,
                            Open = y.StockPrice.Open
                        },
                        Volume = y.Volume
                    }).ToList(),
                    StockSymbol = x.StockSymbol
                }).ToList()
            };
        }
    }
}
