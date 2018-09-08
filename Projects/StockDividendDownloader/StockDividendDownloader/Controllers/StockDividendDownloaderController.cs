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
    public class StockDividendDownloaderController : Controller
    {
        private readonly IStockDividendDataRetriever _stockDividendDataRetriever;
        //private readonly IStockDataRetriever _stockDataRetriever;

        public StockDividendDownloaderController(IStockDividendDataRetriever stockDividendDataRetriever)
            //, IStockDataRetriever stockDataRetriever)
        {
            _stockDividendDataRetriever = stockDividendDataRetriever;
            //_stockDataRetriever = stockDataRetriever;
        }

        [HttpGet("[stock]")]
        public async Task<IActionResult> GetStock(string stock)
        {
            var response = new GetStockResponse();
            return Ok(response);
        }

        [HttpPost("GetStockDividendData")]
        public async Task<IActionResult> GetStockDividendData([FromBody] GetStockDividendDataRequest request)
        {
            var methodName = GetType().Name + ".GetStockDividendData";

            if (!ModelState.IsValid)
            {
                return BadRequest(new GetStockDividendDataResponse
                {
                    CorrelationID = request?.CorrelationID,
                    CallStatus = CallStatus.Failed,
                    Error = new Error
                    {
                        Message = JsonConvert.SerializeObject(BadRequest(ModelState)?.Value)
                    }
                });
            }

            var stockDividendDataRetrieverResponse = _stockDividendDataRetriever.Retrieve((StockDividendDataRetrieverRequest)request).Result;
            return Ok((GetStockDividendDataResponse) stockDividendDataRetrieverResponse);
        }

        [HttpPost("GetStockData")]
        public async Task<IActionResult> GetStockData([FromBody] GetStockDataRequest request)
        {
            var methodName = GetType().Name + ".GetStockData";
            if (!ModelState.IsValid)
            {
                return BadRequest(new GetStockDataResponse
                {
                    CorrelationID = request.CorrelationID,
                    CallStatus = CallStatus.Failed,
                    Error = new Error
                    {
                        Message = JsonConvert.SerializeObject(BadRequest(ModelState)?.Value)
                    }
                });
            }

            //var stockDataRetrieverResponse = _stockDataRetriever.Retrieve();
            return Ok();
        }
    }
}
