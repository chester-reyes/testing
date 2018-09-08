﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using StockDividendDownloader.Shared.Types;

namespace StockDividendDownloader.Contract.Messages
{
    [DataContract]
    public class GetStockDividendDataRequest : Request
    {
        [DataMember]
        public IEnumerable<string> StockList { get; set; }
        [DataMember]
        public int NumOfYears { get; set; }
    }
}
