using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stocks_Visualizer.Server.Models.Domain
{
    public class Stock
    {
        public Guid Id { get; set; }
        //public string Information { get; set; }
        public string Symbol { get; set; }
        //public DateTime LastRefreshed { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
        public string TimeZone { get; set; }
        public ICollection<TimeSeriesData> TimeSeries { get; set; }
    }

}
