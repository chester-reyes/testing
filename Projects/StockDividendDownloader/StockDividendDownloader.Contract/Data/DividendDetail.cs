using System;
using System.Collections.Generic;
using System.Text;

namespace StockDividendDownloader.Contract.Data
{
    public class DividendDetail
    {
        public string exDate { get; set; }
        public string paymentDate { get; set; }
        public string recordDate { get; set; }
        public string declaredDate { get; set; }
        public string amount { get; set; }
        public string flag { get; set; }
        public string type { get; set; }
        public string qualified { get; set; }
        public string indicated { get; set; }
    }
}
