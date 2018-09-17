using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockDividendDownloader.Contract.Messages;
using StockDividendDownloader.Model.Interfaces;
using StockDividendDownloader.Model.Messages;
using StockDividendDownloader.Shared.Types;

namespace StockDividendDownloader.Controllers
{
    [Route("api/[controller]")]
    public class StockDataDownloaderController : Controller
    {
        private readonly IStockDataHandler _stockDataHandler;

        public StockDataDownloaderController(IStockDataHandler stockDataHandler)
        {
            _stockDataHandler = stockDataHandler;
        }

        [HttpPost("GetStockData")]
        public async Task<IActionResult> GetStockData([FromBody] GetStockDataRequest request)
        {
            var methodName = GetType().Name + ".GetStockDividendData";

            if (!ModelState.IsValid)
            {
                return BadRequest(new GetStockDataResponse
                {
                    CorrelationID = request?.CorrelationID,
                    CallStatus = CallStatus.Failed,
                    Error = new Error
                    {
                        Message = JsonConvert.SerializeObject(BadRequest(ModelState)?.Value)
                    }
                });
            }

            var stockDividendDataRetrieverResponse = _stockDataHandler.Handle((GetStockDataHandlerRequest)request).Result;
            return Ok((GetStockDataResponse)stockDividendDataRetrieverResponse);
        }
    }
}
