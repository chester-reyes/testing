using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Model.Data
{
    public class DividendDetail
    {
        public string ExDate { get; set; }
        public string Type { get; set; }
        public string CashAmount { get; set; }
        public string DeclarationDate { get; set; }
        public string RecordDate { get; set; }
        public string PaymentDate { get; set; }

        public static explicit operator Contract.Data.DividendDetail(DividendDetail detail)
        {
            if (detail == null)
                return null;

            return new Contract.Data.DividendDetail
            {
                ExDate = detail.ExDate,
                CashAmount = detail.CashAmount,
                DeclarationDate = detail.DeclarationDate,
                PaymentDate = detail.PaymentDate,
                RecordDate = detail.RecordDate,
                Type = detail.Type
            };
        }
    }
}
