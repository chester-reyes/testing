using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StockDividendDownloader.Controllers
{
    [Route("api/[controller]")]
    public class StockDividendDownloaderController : Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get([FromBody] Contract.Messages.GetStockDividendDataRequest request)
        {
        }
    }
}
