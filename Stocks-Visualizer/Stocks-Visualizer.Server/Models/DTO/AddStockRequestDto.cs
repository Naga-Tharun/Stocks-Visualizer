using Stocks_Visualizer.Server.Models.Domain;

namespace Stocks_Visualizer.Server.Models.DTO
{
    public class AddStockRequestDto
    {
        public string Symbol { get; set; }
        public string Interval { get; set; }
    }
}
