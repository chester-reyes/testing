using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Model.Data
{
    public class DividendDetail
    {
        public string exDate { get; set; }
        public string paymentDate { get; set; }
        public string recordDate { get; set; }
        public string declaredDate { get; set; }
        public double amount { get; set; }
        public string flag { get; set; }
        public string type { get; set; }
        public string qualified { get; set; }
        public string indicated { get; set; }

        public static explicit operator Contract.Data.DividendDetail(DividendDetail detail)
        {
            if (detail == null)
                return null;

            return new Contract.Data.DividendDetail
            {
                exDate = detail.exDate,
                paymentDate = detail.paymentDate,
                recordDate = detail.recordDate,
                declaredDate = detail.declaredDate,
                amount = detail.amount,
                flag = detail.flag,
                type = detail.type,
                qualified = detail.qualified,
                indicated = detail.indicated
            };
        }
    }
}
