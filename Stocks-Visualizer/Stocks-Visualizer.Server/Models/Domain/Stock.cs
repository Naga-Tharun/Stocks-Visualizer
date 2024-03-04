using Newtonsoft.Json;

namespace Stocks_Visualizer.Server.Models.Domain
{
    public class Stock
    {
        public MetaData MetaData { get; set; }
        public Dictionary<DateTime, TimeSeriesData> TimeSeries { get; set; }
    }

    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public DateTime LastRefreshed { get; set; }

        [JsonProperty("4. Interval")]
        public string Interval { get; set; }

        [JsonProperty("5. Output Size")]
        public string OutputSize { get; set; }

        [JsonProperty("6. Time Zone")]
        public string TimeZone { get; set; }
    }

    public class TimeSeriesData
    {
        [JsonProperty("1. open")]
        public decimal Open { get; set; }

        [JsonProperty("2. high")]
        public decimal High { get; set; }

        [JsonProperty("3. low")]
        public decimal Low { get; set; }

        [JsonProperty("4. close")]
        public decimal Close { get; set; }

        [JsonProperty("5. volume")]
        public int Volume { get; set; }
    }
}
