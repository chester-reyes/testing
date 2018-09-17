using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Contract.Data
{
    public class DividendDetail
    {
        public string ExDate { get; set; }
        public string Type { get; set; }
        public string CashAmount { get; set; }
        public string DeclarationDate { get; set; }
        public string RecordDate { get; set; }
        public string PaymentDate { get; set; }
    }
}
