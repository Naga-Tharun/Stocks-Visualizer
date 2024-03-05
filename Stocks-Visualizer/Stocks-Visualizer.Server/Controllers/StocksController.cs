using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stocks_Visualizer.Server.Models.Domain;
using Stocks_Visualizer.Server.Models.DTO;
using Stocks_Visualizer.Server.Repositories.Interface;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;

namespace Stocks_Visualizer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository stockRepository;

        private readonly IHttpClientFactory httpClientFactory;

        public StocksController(IStockRepository stockRepository, IHttpClientFactory httpClientFactory)
        {
            this.stockRepository = stockRepository;
            this.httpClientFactory = httpClientFactory;
        }

        // 
        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] AddStockRequestDto request)
        {

            try
            {
                var apiUrl = "";

                if (request.TimeFrame == "intraday")
                {
                    if (request.Interval == null)
                    {
                        return BadRequest("Interval is required for intraday time frame");
                    }

                    apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_{request.TimeFrame}&symbol={request.Symbol}&interval={request.Interval}&apikey=2XUP1DI8XMATRETW";
                }
                else
                {
                    apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_{request.TimeFrame}&symbol={request.Symbol}&apikey=2XUP1DI8XMATRETW";
                }


                using (var httpClient = httpClientFactory.CreateClient())
                {
                    var ApiResponse = await httpClient.GetStringAsync(apiUrl);

                    // Deserialize the JSON response from Alpha Vantage
                    // var alphaVantageResponse = JsonConvert.DeserializeObject<AlphaVantageResponseDto>(response);

                    // Now you have the data in alphaVantageResponse.TimeSeries
                    // You can transform and store it in your database here
                    // For example, you can use your DbContext to save the data

                    //var avResponse = JsonConvert.DeserializeObject(response);
                    
                    //var timeSeries = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>((string)avResponse);

                    if (request.TimeFrame == "intraday")
                    {
                        // testing string
                        ApiResponse = "{\r\n    \"Meta Data\": {\r\n        \"1. Information\": \"Intraday (5min) open, high, low, close prices and volume\",\r\n        \"2. Symbol\": \"IBM\",\r\n        \"3. Last Refreshed\": \"2024-03-04 19:55:00\",\r\n        \"4. Interval\": \"5min\",\r\n        \"5. Output Size\": \"Compact\",\r\n        \"6. Time Zone\": \"US/Eastern\"\r\n    },\r\n    \"Time Series (5min)\": {\r\n        \"2024-03-04 19:55:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"193.0000\",\r\n            \"4. close\": \"193.0000\",\r\n            \"5. volume\": \"54\"\r\n        },\r\n        \"2024-03-04 19:50:00\": {\r\n            \"1. open\": \"192.9000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.9000\",\r\n            \"4. close\": \"192.9000\",\r\n            \"5. volume\": \"90\"\r\n        },\r\n        \"2024-03-04 19:45:00\": {\r\n            \"1. open\": \"192.7300\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.7300\",\r\n            \"4. close\": \"193.0000\",\r\n            \"5. volume\": \"29\"\r\n        },\r\n        \"2024-03-04 19:40:00\": {\r\n            \"1. open\": \"192.8000\",\r\n            \"2. high\": \"192.9900\",\r\n            \"3. low\": \"192.8000\",\r\n            \"4. close\": \"192.9000\",\r\n            \"5. volume\": \"36\"\r\n        },\r\n        \"2024-03-04 19:35:00\": {\r\n            \"1. open\": \"192.8000\",\r\n            \"2. high\": \"192.8000\",\r\n            \"3. low\": \"192.1000\",\r\n            \"4. close\": \"192.1000\",\r\n            \"5. volume\": \"19\"\r\n        },\r\n        \"2024-03-04 19:30:00\": {\r\n            \"1. open\": \"192.8000\",\r\n            \"2. high\": \"192.8000\",\r\n            \"3. low\": \"192.8000\",\r\n            \"4. close\": \"192.8000\",\r\n            \"5. volume\": \"145\"\r\n        },\r\n        \"2024-03-04 19:25:00\": {\r\n            \"1. open\": \"192.8000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.7600\",\r\n            \"5. volume\": \"140\"\r\n        },\r\n        \"2024-03-04 19:20:00\": {\r\n            \"1. open\": \"192.8000\",\r\n            \"2. high\": \"192.8000\",\r\n            \"3. low\": \"192.7600\",\r\n            \"4. close\": \"192.7600\",\r\n            \"5. volume\": \"11\"\r\n        },\r\n        \"2024-03-04 19:15:00\": {\r\n            \"1. open\": \"192.9000\",\r\n            \"2. high\": \"192.9000\",\r\n            \"3. low\": \"192.7900\",\r\n            \"4. close\": \"192.8000\",\r\n            \"5. volume\": \"167\"\r\n        },\r\n        \"2024-03-04 19:10:00\": {\r\n            \"1. open\": \"192.7500\",\r\n            \"2. high\": \"192.7520\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.7520\",\r\n            \"5. volume\": \"25\"\r\n        },\r\n        \"2024-03-04 19:05:00\": {\r\n            \"1. open\": \"192.8300\",\r\n            \"2. high\": \"192.8800\",\r\n            \"3. low\": \"192.7900\",\r\n            \"4. close\": \"192.8800\",\r\n            \"5. volume\": \"123\"\r\n        },\r\n        \"2024-03-04 19:00:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.0600\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.8300\",\r\n            \"5. volume\": \"827445\"\r\n        },\r\n        \"2024-03-04 18:55:00\": {\r\n            \"1. open\": \"192.8300\",\r\n            \"2. high\": \"192.9600\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.9600\",\r\n            \"5. volume\": \"107\"\r\n        },\r\n        \"2024-03-04 18:50:00\": {\r\n            \"1. open\": \"192.8600\",\r\n            \"2. high\": \"192.8600\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.8300\",\r\n            \"5. volume\": \"15\"\r\n        },\r\n        \"2024-03-04 18:40:00\": {\r\n            \"1. open\": \"192.8900\",\r\n            \"2. high\": \"192.8900\",\r\n            \"3. low\": \"192.8900\",\r\n            \"4. close\": \"192.8900\",\r\n            \"5. volume\": \"1\"\r\n        },\r\n        \"2024-03-04 18:30:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.0600\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.8300\",\r\n            \"5. volume\": \"827264\"\r\n        },\r\n        \"2024-03-04 18:25:00\": {\r\n            \"1. open\": \"192.9000\",\r\n            \"2. high\": \"192.9000\",\r\n            \"3. low\": \"192.8900\",\r\n            \"4. close\": \"192.8900\",\r\n            \"5. volume\": \"2\"\r\n        },\r\n        \"2024-03-04 18:15:00\": {\r\n            \"1. open\": \"192.8900\",\r\n            \"2. high\": \"192.8900\",\r\n            \"3. low\": \"192.8900\",\r\n            \"4. close\": \"192.8900\",\r\n            \"5. volume\": \"1\"\r\n        },\r\n        \"2024-03-04 18:10:00\": {\r\n            \"1. open\": \"192.8300\",\r\n            \"2. high\": \"192.9100\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.8300\",\r\n            \"5. volume\": \"295\"\r\n        },\r\n        \"2024-03-04 18:05:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.9100\",\r\n            \"4. close\": \"192.9100\",\r\n            \"5. volume\": \"64\"\r\n        },\r\n        \"2024-03-04 18:00:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.9000\",\r\n            \"5. volume\": \"215\"\r\n        },\r\n        \"2024-03-04 17:55:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"193.0000\",\r\n            \"4. close\": \"193.0000\",\r\n            \"5. volume\": \"77\"\r\n        },\r\n        \"2024-03-04 17:50:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"193.0000\",\r\n            \"5. volume\": \"443\"\r\n        },\r\n        \"2024-03-04 17:45:00\": {\r\n            \"1. open\": \"192.9000\",\r\n            \"2. high\": \"192.9900\",\r\n            \"3. low\": \"192.9000\",\r\n            \"4. close\": \"192.9900\",\r\n            \"5. volume\": \"84\"\r\n        },\r\n        \"2024-03-04 17:40:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.8300\",\r\n            \"4. close\": \"192.9000\",\r\n            \"5. volume\": \"181\"\r\n        },\r\n        \"2024-03-04 17:35:00\": {\r\n            \"1. open\": \"192.9600\",\r\n            \"2. high\": \"192.9700\",\r\n            \"3. low\": \"192.8600\",\r\n            \"4. close\": \"192.9000\",\r\n            \"5. volume\": \"175\"\r\n        },\r\n        \"2024-03-04 17:25:00\": {\r\n            \"1. open\": \"192.8800\",\r\n            \"2. high\": \"192.9600\",\r\n            \"3. low\": \"192.8800\",\r\n            \"4. close\": \"192.9600\",\r\n            \"5. volume\": \"84\"\r\n        },\r\n        \"2024-03-04 17:20:00\": {\r\n            \"1. open\": \"192.7500\",\r\n            \"2. high\": \"192.8300\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.8300\",\r\n            \"5. volume\": \"11\"\r\n        },\r\n        \"2024-03-04 17:15:00\": {\r\n            \"1. open\": \"192.9300\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.9300\",\r\n            \"4. close\": \"193.0000\",\r\n            \"5. volume\": \"250\"\r\n        },\r\n        \"2024-03-04 17:10:00\": {\r\n            \"1. open\": \"193.0000\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.7500\",\r\n            \"5. volume\": \"59\"\r\n        },\r\n        \"2024-03-04 17:05:00\": {\r\n            \"1. open\": \"192.8200\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.8200\",\r\n            \"5. volume\": \"17\"\r\n        },\r\n        \"2024-03-04 17:00:00\": {\r\n            \"1. open\": \"192.9300\",\r\n            \"2. high\": \"193.0600\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.7600\",\r\n            \"5. volume\": \"191\"\r\n        },\r\n        \"2024-03-04 16:55:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.0600\",\r\n            \"3. low\": \"192.7000\",\r\n            \"4. close\": \"192.9400\",\r\n            \"5. volume\": \"213\"\r\n        },\r\n        \"2024-03-04 16:50:00\": {\r\n            \"1. open\": \"192.9900\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.7000\",\r\n            \"4. close\": \"192.8300\",\r\n            \"5. volume\": \"241\"\r\n        },\r\n        \"2024-03-04 16:40:00\": {\r\n            \"1. open\": \"192.9900\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.9800\",\r\n            \"4. close\": \"192.9800\",\r\n            \"5. volume\": \"10\"\r\n        },\r\n        \"2024-03-04 16:35:00\": {\r\n            \"1. open\": \"192.9900\",\r\n            \"2. high\": \"192.9900\",\r\n            \"3. low\": \"192.9900\",\r\n            \"4. close\": \"192.9900\",\r\n            \"5. volume\": \"32\"\r\n        },\r\n        \"2024-03-04 16:30:00\": {\r\n            \"1. open\": \"192.6500\",\r\n            \"2. high\": \"192.9200\",\r\n            \"3. low\": \"192.1430\",\r\n            \"4. close\": \"192.7100\",\r\n            \"5. volume\": \"1210\"\r\n        },\r\n        \"2024-03-04 16:25:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.1000\",\r\n            \"3. low\": \"192.1140\",\r\n            \"4. close\": \"192.8000\",\r\n            \"5. volume\": \"2564\"\r\n        },\r\n        \"2024-03-04 16:20:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.1000\",\r\n            \"3. low\": \"186.8650\",\r\n            \"4. close\": \"192.1000\",\r\n            \"5. volume\": \"1390\"\r\n        },\r\n        \"2024-03-04 16:15:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.1000\",\r\n            \"3. low\": \"192.0000\",\r\n            \"4. close\": \"193.1000\",\r\n            \"5. volume\": \"1710\"\r\n        },\r\n        \"2024-03-04 16:10:00\": {\r\n            \"1. open\": \"193.0600\",\r\n            \"2. high\": \"193.0800\",\r\n            \"3. low\": \"192.9100\",\r\n            \"4. close\": \"192.9100\",\r\n            \"5. volume\": \"827503\"\r\n        },\r\n        \"2024-03-04 16:05:00\": {\r\n            \"1. open\": \"193.3200\",\r\n            \"2. high\": \"193.3300\",\r\n            \"3. low\": \"193.0300\",\r\n            \"4. close\": \"193.1000\",\r\n            \"5. volume\": \"1301\"\r\n        },\r\n        \"2024-03-04 16:00:00\": {\r\n            \"1. open\": \"193.0900\",\r\n            \"2. high\": \"193.0900\",\r\n            \"3. low\": \"193.0400\",\r\n            \"4. close\": \"193.0700\",\r\n            \"5. volume\": \"1762923\"\r\n        },\r\n        \"2024-03-04 15:55:00\": {\r\n            \"1. open\": \"192.8800\",\r\n            \"2. high\": \"193.2500\",\r\n            \"3. low\": \"192.7800\",\r\n            \"4. close\": \"193.0900\",\r\n            \"5. volume\": \"580448\"\r\n        },\r\n        \"2024-03-04 15:50:00\": {\r\n            \"1. open\": \"193.0100\",\r\n            \"2. high\": \"193.1900\",\r\n            \"3. low\": \"192.8400\",\r\n            \"4. close\": \"192.8750\",\r\n            \"5. volume\": \"201801\"\r\n        },\r\n        \"2024-03-04 15:45:00\": {\r\n            \"1. open\": \"193.1850\",\r\n            \"2. high\": \"193.1850\",\r\n            \"3. low\": \"192.8330\",\r\n            \"4. close\": \"192.9850\",\r\n            \"5. volume\": \"125420\"\r\n        },\r\n        \"2024-03-04 15:40:00\": {\r\n            \"1. open\": \"193.1550\",\r\n            \"2. high\": \"193.3700\",\r\n            \"3. low\": \"193.1550\",\r\n            \"4. close\": \"193.1900\",\r\n            \"5. volume\": \"90633\"\r\n        },\r\n        \"2024-03-04 15:35:00\": {\r\n            \"1. open\": \"193.2450\",\r\n            \"2. high\": \"193.2450\",\r\n            \"3. low\": \"192.8950\",\r\n            \"4. close\": \"193.1500\",\r\n            \"5. volume\": \"105389\"\r\n        },\r\n        \"2024-03-04 15:30:00\": {\r\n            \"1. open\": \"193.1800\",\r\n            \"2. high\": \"193.4700\",\r\n            \"3. low\": \"193.1740\",\r\n            \"4. close\": \"193.2250\",\r\n            \"5. volume\": \"83140\"\r\n        },\r\n        \"2024-03-04 15:25:00\": {\r\n            \"1. open\": \"193.4450\",\r\n            \"2. high\": \"193.4800\",\r\n            \"3. low\": \"193.1600\",\r\n            \"4. close\": \"193.1800\",\r\n            \"5. volume\": \"67123\"\r\n        },\r\n        \"2024-03-04 15:20:00\": {\r\n            \"1. open\": \"193.7250\",\r\n            \"2. high\": \"193.7300\",\r\n            \"3. low\": \"193.4300\",\r\n            \"4. close\": \"193.4450\",\r\n            \"5. volume\": \"60658\"\r\n        },\r\n        \"2024-03-04 15:15:00\": {\r\n            \"1. open\": \"193.7100\",\r\n            \"2. high\": \"193.8950\",\r\n            \"3. low\": \"193.6500\",\r\n            \"4. close\": \"193.7200\",\r\n            \"5. volume\": \"72585\"\r\n        },\r\n        \"2024-03-04 15:10:00\": {\r\n            \"1. open\": \"193.7600\",\r\n            \"2. high\": \"193.8980\",\r\n            \"3. low\": \"193.6700\",\r\n            \"4. close\": \"193.7190\",\r\n            \"5. volume\": \"80664\"\r\n        },\r\n        \"2024-03-04 15:05:00\": {\r\n            \"1. open\": \"193.2750\",\r\n            \"2. high\": \"193.7700\",\r\n            \"3. low\": \"193.2600\",\r\n            \"4. close\": \"193.7700\",\r\n            \"5. volume\": \"79541\"\r\n        },\r\n        \"2024-03-04 15:00:00\": {\r\n            \"1. open\": \"193.3100\",\r\n            \"2. high\": \"193.3400\",\r\n            \"3. low\": \"193.2000\",\r\n            \"4. close\": \"193.2800\",\r\n            \"5. volume\": \"52361\"\r\n        },\r\n        \"2024-03-04 14:55:00\": {\r\n            \"1. open\": \"193.4600\",\r\n            \"2. high\": \"193.5700\",\r\n            \"3. low\": \"193.3200\",\r\n            \"4. close\": \"193.3300\",\r\n            \"5. volume\": \"60657\"\r\n        },\r\n        \"2024-03-04 14:50:00\": {\r\n            \"1. open\": \"193.2100\",\r\n            \"2. high\": \"193.4900\",\r\n            \"3. low\": \"193.1800\",\r\n            \"4. close\": \"193.4750\",\r\n            \"5. volume\": \"55026\"\r\n        },\r\n        \"2024-03-04 14:45:00\": {\r\n            \"1. open\": \"193.2600\",\r\n            \"2. high\": \"193.3400\",\r\n            \"3. low\": \"193.1550\",\r\n            \"4. close\": \"193.1970\",\r\n            \"5. volume\": \"54112\"\r\n        },\r\n        \"2024-03-04 14:40:00\": {\r\n            \"1. open\": \"193.2300\",\r\n            \"2. high\": \"193.2550\",\r\n            \"3. low\": \"193.0400\",\r\n            \"4. close\": \"193.2500\",\r\n            \"5. volume\": \"39696\"\r\n        },\r\n        \"2024-03-04 14:35:00\": {\r\n            \"1. open\": \"192.9240\",\r\n            \"2. high\": \"193.1960\",\r\n            \"3. low\": \"192.9000\",\r\n            \"4. close\": \"193.1970\",\r\n            \"5. volume\": \"75236\"\r\n        },\r\n        \"2024-03-04 14:30:00\": {\r\n            \"1. open\": \"192.8550\",\r\n            \"2. high\": \"192.9900\",\r\n            \"3. low\": \"192.7100\",\r\n            \"4. close\": \"192.9150\",\r\n            \"5. volume\": \"64284\"\r\n        },\r\n        \"2024-03-04 14:25:00\": {\r\n            \"1. open\": \"193.0800\",\r\n            \"2. high\": \"193.1100\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.8550\",\r\n            \"5. volume\": \"58398\"\r\n        },\r\n        \"2024-03-04 14:20:00\": {\r\n            \"1. open\": \"193.1850\",\r\n            \"2. high\": \"193.2000\",\r\n            \"3. low\": \"193.0200\",\r\n            \"4. close\": \"193.0890\",\r\n            \"5. volume\": \"47527\"\r\n        },\r\n        \"2024-03-04 14:15:00\": {\r\n            \"1. open\": \"193.0200\",\r\n            \"2. high\": \"193.2100\",\r\n            \"3. low\": \"193.0000\",\r\n            \"4. close\": \"193.2000\",\r\n            \"5. volume\": \"66474\"\r\n        },\r\n        \"2024-03-04 14:10:00\": {\r\n            \"1. open\": \"192.9150\",\r\n            \"2. high\": \"193.0500\",\r\n            \"3. low\": \"192.8500\",\r\n            \"4. close\": \"193.0200\",\r\n            \"5. volume\": \"41273\"\r\n        },\r\n        \"2024-03-04 14:05:00\": {\r\n            \"1. open\": \"192.9500\",\r\n            \"2. high\": \"192.9800\",\r\n            \"3. low\": \"192.8600\",\r\n            \"4. close\": \"192.9100\",\r\n            \"5. volume\": \"38634\"\r\n        },\r\n        \"2024-03-04 14:00:00\": {\r\n            \"1. open\": \"192.9700\",\r\n            \"2. high\": \"193.0550\",\r\n            \"3. low\": \"192.8700\",\r\n            \"4. close\": \"192.9700\",\r\n            \"5. volume\": \"40776\"\r\n        },\r\n        \"2024-03-04 13:55:00\": {\r\n            \"1. open\": \"192.7800\",\r\n            \"2. high\": \"193.0800\",\r\n            \"3. low\": \"192.7100\",\r\n            \"4. close\": \"192.9650\",\r\n            \"5. volume\": \"53267\"\r\n        },\r\n        \"2024-03-04 13:50:00\": {\r\n            \"1. open\": \"192.7530\",\r\n            \"2. high\": \"192.7900\",\r\n            \"3. low\": \"192.7000\",\r\n            \"4. close\": \"192.7700\",\r\n            \"5. volume\": \"25120\"\r\n        },\r\n        \"2024-03-04 13:45:00\": {\r\n            \"1. open\": \"192.8000\",\r\n            \"2. high\": \"192.9200\",\r\n            \"3. low\": \"192.7500\",\r\n            \"4. close\": \"192.7700\",\r\n            \"5. volume\": \"48897\"\r\n        },\r\n        \"2024-03-04 13:40:00\": {\r\n            \"1. open\": \"192.4100\",\r\n            \"2. high\": \"192.7700\",\r\n            \"3. low\": \"192.3700\",\r\n            \"4. close\": \"192.7700\",\r\n            \"5. volume\": \"39407\"\r\n        },\r\n        \"2024-03-04 13:35:00\": {\r\n            \"1. open\": \"192.4650\",\r\n            \"2. high\": \"192.5400\",\r\n            \"3. low\": \"192.3400\",\r\n            \"4. close\": \"192.4250\",\r\n            \"5. volume\": \"32444\"\r\n        },\r\n        \"2024-03-04 13:30:00\": {\r\n            \"1. open\": \"192.6900\",\r\n            \"2. high\": \"192.6900\",\r\n            \"3. low\": \"192.4650\",\r\n            \"4. close\": \"192.4650\",\r\n            \"5. volume\": \"43441\"\r\n        },\r\n        \"2024-03-04 13:25:00\": {\r\n            \"1. open\": \"192.6700\",\r\n            \"2. high\": \"192.7600\",\r\n            \"3. low\": \"192.5810\",\r\n            \"4. close\": \"192.7050\",\r\n            \"5. volume\": \"36610\"\r\n        },\r\n        \"2024-03-04 13:20:00\": {\r\n            \"1. open\": \"192.9800\",\r\n            \"2. high\": \"193.0500\",\r\n            \"3. low\": \"192.5860\",\r\n            \"4. close\": \"192.6850\",\r\n            \"5. volume\": \"60296\"\r\n        },\r\n        \"2024-03-04 13:15:00\": {\r\n            \"1. open\": \"193.2100\",\r\n            \"2. high\": \"193.2100\",\r\n            \"3. low\": \"192.9900\",\r\n            \"4. close\": \"192.9900\",\r\n            \"5. volume\": \"37110\"\r\n        },\r\n        \"2024-03-04 13:10:00\": {\r\n            \"1. open\": \"193.2100\",\r\n            \"2. high\": \"193.3000\",\r\n            \"3. low\": \"193.1380\",\r\n            \"4. close\": \"193.2100\",\r\n            \"5. volume\": \"37445\"\r\n        },\r\n        \"2024-03-04 13:05:00\": {\r\n            \"1. open\": \"192.9400\",\r\n            \"2. high\": \"193.2200\",\r\n            \"3. low\": \"192.9100\",\r\n            \"4. close\": \"193.2000\",\r\n            \"5. volume\": \"42440\"\r\n        },\r\n        \"2024-03-04 13:00:00\": {\r\n            \"1. open\": \"192.9900\",\r\n            \"2. high\": \"193.0200\",\r\n            \"3. low\": \"192.8800\",\r\n            \"4. close\": \"192.9500\",\r\n            \"5. volume\": \"35313\"\r\n        },\r\n        \"2024-03-04 12:55:00\": {\r\n            \"1. open\": \"192.9410\",\r\n            \"2. high\": \"193.0600\",\r\n            \"3. low\": \"192.9400\",\r\n            \"4. close\": \"192.9650\",\r\n            \"5. volume\": \"44466\"\r\n        },\r\n        \"2024-03-04 12:50:00\": {\r\n            \"1. open\": \"193.0200\",\r\n            \"2. high\": \"193.1300\",\r\n            \"3. low\": \"192.9200\",\r\n            \"4. close\": \"192.9650\",\r\n            \"5. volume\": \"44487\"\r\n        },\r\n        \"2024-03-04 12:45:00\": {\r\n            \"1. open\": \"193.1000\",\r\n            \"2. high\": \"193.2400\",\r\n            \"3. low\": \"192.9600\",\r\n            \"4. close\": \"192.9600\",\r\n            \"5. volume\": \"47655\"\r\n        },\r\n        \"2024-03-04 12:40:00\": {\r\n            \"1. open\": \"193.3000\",\r\n            \"2. high\": \"193.3000\",\r\n            \"3. low\": \"193.0900\",\r\n            \"4. close\": \"193.1100\",\r\n            \"5. volume\": \"49671\"\r\n        },\r\n        \"2024-03-04 12:35:00\": {\r\n            \"1. open\": \"193.2700\",\r\n            \"2. high\": \"193.3900\",\r\n            \"3. low\": \"193.2000\",\r\n            \"4. close\": \"193.3000\",\r\n            \"5. volume\": \"41284\"\r\n        },\r\n        \"2024-03-04 12:30:00\": {\r\n            \"1. open\": \"193.4450\",\r\n            \"2. high\": \"193.4900\",\r\n            \"3. low\": \"193.3000\",\r\n            \"4. close\": \"193.3000\",\r\n            \"5. volume\": \"32983\"\r\n        },\r\n        \"2024-03-04 12:25:00\": {\r\n            \"1. open\": \"193.5110\",\r\n            \"2. high\": \"193.5900\",\r\n            \"3. low\": \"193.3500\",\r\n            \"4. close\": \"193.4400\",\r\n            \"5. volume\": \"48534\"\r\n        },\r\n        \"2024-03-04 12:20:00\": {\r\n            \"1. open\": \"193.2900\",\r\n            \"2. high\": \"193.6600\",\r\n            \"3. low\": \"193.2420\",\r\n            \"4. close\": \"193.5300\",\r\n            \"5. volume\": \"50665\"\r\n        },\r\n        \"2024-03-04 12:15:00\": {\r\n            \"1. open\": \"192.8100\",\r\n            \"2. high\": \"193.3100\",\r\n            \"3. low\": \"192.8000\",\r\n            \"4. close\": \"193.2270\",\r\n            \"5. volume\": \"57393\"\r\n        },\r\n        \"2024-03-04 12:10:00\": {\r\n            \"1. open\": \"192.8100\",\r\n            \"2. high\": \"193.0000\",\r\n            \"3. low\": \"192.6900\",\r\n            \"4. close\": \"192.7750\",\r\n            \"5. volume\": \"51095\"\r\n        },\r\n        \"2024-03-04 12:05:00\": {\r\n            \"1. open\": \"192.8300\",\r\n            \"2. high\": \"192.8800\",\r\n            \"3. low\": \"192.5800\",\r\n            \"4. close\": \"192.8000\",\r\n            \"5. volume\": \"95355\"\r\n        },\r\n        \"2024-03-04 12:00:00\": {\r\n            \"1. open\": \"192.9500\",\r\n            \"2. high\": \"192.9500\",\r\n            \"3. low\": \"192.6500\",\r\n            \"4. close\": \"192.8000\",\r\n            \"5. volume\": \"44593\"\r\n        },\r\n        \"2024-03-04 11:55:00\": {\r\n            \"1. open\": \"193.0150\",\r\n            \"2. high\": \"193.1650\",\r\n            \"3. low\": \"192.8000\",\r\n            \"4. close\": \"192.9200\",\r\n            \"5. volume\": \"80069\"\r\n        },\r\n        \"2024-03-04 11:50:00\": {\r\n            \"1. open\": \"193.3500\",\r\n            \"2. high\": \"193.4800\",\r\n            \"3. low\": \"192.9400\",\r\n            \"4. close\": \"193.0000\",\r\n            \"5. volume\": \"62387\"\r\n        },\r\n        \"2024-03-04 11:45:00\": {\r\n            \"1. open\": \"193.0500\",\r\n            \"2. high\": \"193.4300\",\r\n            \"3. low\": \"193.0200\",\r\n            \"4. close\": \"193.3600\",\r\n            \"5. volume\": \"89243\"\r\n        },\r\n        \"2024-03-04 11:40:00\": {\r\n            \"1. open\": \"192.6900\",\r\n            \"2. high\": \"193.1200\",\r\n            \"3. low\": \"192.6700\",\r\n            \"4. close\": \"193.0200\",\r\n            \"5. volume\": \"89631\"\r\n        },\r\n        \"2024-03-04 11:35:00\": {\r\n            \"1. open\": \"192.6400\",\r\n            \"2. high\": \"192.8200\",\r\n            \"3. low\": \"192.6000\",\r\n            \"4. close\": \"192.6700\",\r\n            \"5. volume\": \"83132\"\r\n        },\r\n        \"2024-03-04 11:30:00\": {\r\n            \"1. open\": \"192.8800\",\r\n            \"2. high\": \"193.2000\",\r\n            \"3. low\": \"192.6400\",\r\n            \"4. close\": \"192.6400\",\r\n            \"5. volume\": \"156853\"\r\n        },\r\n        \"2024-03-04 11:25:00\": {\r\n            \"1. open\": \"192.3900\",\r\n            \"2. high\": \"192.8800\",\r\n            \"3. low\": \"192.2800\",\r\n            \"4. close\": \"192.8800\",\r\n            \"5. volume\": \"129837\"\r\n        },\r\n        \"2024-03-04 11:20:00\": {\r\n            \"1. open\": \"191.9700\",\r\n            \"2. high\": \"192.4800\",\r\n            \"3. low\": \"191.9700\",\r\n            \"4. close\": \"192.4000\",\r\n            \"5. volume\": \"112703\"\r\n        },\r\n        \"2024-03-04 11:15:00\": {\r\n            \"1. open\": \"191.4800\",\r\n            \"2. high\": \"191.9900\",\r\n            \"3. low\": \"191.3770\",\r\n            \"4. close\": \"191.9900\",\r\n            \"5. volume\": \"121030\"\r\n        }\r\n    }\r\n}";
                        
                        StockIntradayApiResponseDto stockApiResponse = JsonConvert.DeserializeObject<StockIntradayApiResponseDto>(ApiResponse);
                        MetaDataApiResponseDto metaData = stockApiResponse.MetaData;
                        Dictionary<string, TimeSeriesDataApiResponseDto> timeSeries = stockApiResponse.TimeSeries;

                        // Map dto to domain model
                        var stock = new Stock
                        {
                            Symbol = metaData.Symbol,
                            Interval = metaData.Interval,
                            OutputSize = metaData.OutputSize,
                            TimeZone = metaData.TimeZone,
                            TimeSeries = timeSeries.Select(ts => new TimeSeriesData
                            {
                                TimeStamp = DateTime.Parse(ts.Key),
                                Open = ts.Value.Open,
                                High = ts.Value.High,
                                Low = ts.Value.Low,
                                Close = ts.Value.Close,
                                Volume = ts.Value.Volume
                            }).ToList()
                        };

                        stock = await stockRepository.CreateAsync(stock);

                        // Domain model to DTO
                        var response = new StockDto
                        {
                            Id = stock.Id,
                            Symbol = stock.Symbol,
                            Interval = stock.Interval,
                            OutputSize = stock.OutputSize,
                            TimeZone = stock.TimeZone,
                            TimeSeries = stock.TimeSeries.Select(ts => new TimeSeriesDataDto
                            {
                                TimeStamp = ts.TimeStamp,
                                Open = ts.Open,
                                High = ts.High,
                                Low = ts.Low,
                                Close = ts.Close,
                                Volume = ts.Volume
                            }).ToList()
                        };

                        return Ok(response);
                    }
                    else
                    {

                    }



                    return Ok(ApiResponse);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // GET: /api/stocks
        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await stockRepository.GetAllAsync();

            // Map domain model to dto
            var response = new List<StockDto>();
            foreach (var stock in stocks)
            {
                response.Add(new StockDto
                {
                    Id = stock.Id,
                    Symbol = stock.Symbol,
                    Interval = stock.Interval,
                    OutputSize = stock.OutputSize,
                    TimeZone = stock.TimeZone,
                    TimeSeries = stock.TimeSeries.Select(ts => new TimeSeriesDataDto
                    {
                        TimeStamp = ts.TimeStamp,
                        Open = ts.Open,
                        High = ts.High,
                        Low = ts.Low,
                        Close = ts.Close,
                        Volume = ts.Volume
                    }).ToList()
                });
            }

            return Ok(response);
        }

        // Get: /api/stocks/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetStock([FromRoute]Guid id)
        {
            var stock = stockRepository.GetAsync(id);
            var response = new StockViewDto();
            foreach(var timeSeries in stock.TimeSeries)
            {
                response.open.Add(timeSeries.Open);
                response.close.Add(timeSeries.Close);
                response.high.Add(timeSeries.High);
                response.low.Add(timeSeries.Low);
                response.openDate.Add(timeSeries.TimeStamp);
            }
            return Ok(response);
        }
    }
}
