using StockDividendDownloader.Model.Data;
using StockDividendDownloader.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockDividendDownloader.Model.Messages
{
    public class GetStockDataHandlerResponse : Response
    {
        public IEnumerable<StockData> StockList { get; set; }

        public static explicit operator Contract.Messages.GetStockDataResponse(GetStockDataHandlerResponse response)
        {
            if (response == null)
                return null;

            return new Contract.Messages.GetStockDataResponse
            {
                CorrelationID = response.CorrelationID,
                CallStatus = response.CallStatus,
                Error = response.Error,
                StockList = response.StockList.ToList().Select(x => new Contract.Data.StockData
                {
                    StockSymbol = x?.StockSymbol,
                    StockDetails = x?.StockDetails?.ToList().Select(y => new Contract.Data.StockDetail
                    {
                        StockPrice = new Contract.Data.StockPrice
                        {
                            CurrentPrice = y?.StockPrice.CurrentPrice,
                            PreviousClose = y?.StockPrice?.PreviousClose,
                            TodayHigh = y?.StockPrice?.TodayHigh,
                            TodayLow = y?.StockPrice.TodayLow,
                            YearWeekHigh = y?.StockPrice?.YearWeekHigh,
                            YearWeekLow = y?.StockPrice?.YearWeekLow,
                            Volume = y?.StockPrice?.Volume,
                            PERatio = y?.StockPrice?.PERatio
                        }
                    }).ToList(),
                    DividendDetails = x?.DividendDetails?.ToList().Select(z => new Contract.Data.DividendDetail
                    {
                        ExDate = z?.ExDate,
                        CashAmount = z?.CashAmount,
                        DeclarationDate = z?.DeclarationDate,
                        PaymentDate = z?.PaymentDate,
                        RecordDate = z?.RecordDate,
                        Type = z?.Type
                    }).ToList()
                }).ToList()
            };
        }
    }
}
