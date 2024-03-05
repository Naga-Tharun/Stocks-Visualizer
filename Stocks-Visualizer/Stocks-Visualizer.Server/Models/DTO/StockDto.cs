using Stocks_Visualizer.Server.Models.Domain;

namespace Stocks_Visualizer.Server.Models.DTO
{
    public class StockDto
    {
        public Guid Id { get; set; }
        //public string Information { get; set; }
        public string Symbol { get; set; }
        //public DateTime LastRefreshed { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
        public string TimeZone { get; set; }
        public List<TimeSeriesDataDto> TimeSeries { get; set; } = new List<TimeSeriesDataDto>();
    }
}
