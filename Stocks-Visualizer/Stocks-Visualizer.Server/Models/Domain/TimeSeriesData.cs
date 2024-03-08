using Newtonsoft.Json;

namespace Stocks_Visualizer.Server.Models.Domain
{
    public class TimeSeriesData
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public long Volume { get; set; }
    }
}
