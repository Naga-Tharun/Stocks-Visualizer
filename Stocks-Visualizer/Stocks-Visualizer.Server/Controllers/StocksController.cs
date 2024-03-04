using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                var apiUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={request.Symbol}&interval={request.Interval}&apikey=2XUP1DI8XMATRETW";

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
    }
}
