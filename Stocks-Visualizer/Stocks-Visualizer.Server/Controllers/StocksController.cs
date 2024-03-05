using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stocks_Visualizer.Server.Models.Domain;
using Stocks_Visualizer.Server.Models.DTO;
using Stocks_Visualizer.Server.Repositories.Interface;
using System.Net.Http;

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
                    var response = await httpClient.GetStringAsync(apiUrl);

                    // Deserialize the JSON response from Alpha Vantage
                    // var alphaVantageResponse = JsonConvert.DeserializeObject<AlphaVantageResponseDto>(response);

                    // Now you have the data in alphaVantageResponse.TimeSeries
                    // You can transform and store it in your database here
                    // For example, you can use your DbContext to save the data

                    return Ok(response);
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

    }
}
