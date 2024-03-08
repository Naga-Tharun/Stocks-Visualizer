using Newtonsoft.Json;

namespace Stocks_Visualizer.Server.Models.DTO
{

    public class MetaDataIntradayApiResponseDto
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

    public class TimeSeriesDataIntradayApiResponseDto
    {
        [JsonProperty("1. open")]
        public float Open { get; set; }

        [JsonProperty("2. high")]
        public float High { get; set; }

        [JsonProperty("3. low")]
        public float Low { get; set; }

        [JsonProperty("4. close")]
        public float Close { get; set; }

        [JsonProperty("5. volume")]
        public long Volume { get; set; }
    }

    public class StockIntradayApiResponseDto
    {
        [JsonProperty("Meta Data")]
        public MetaDataIntradayApiResponseDto MetaData { get; set; }

        [JsonProperty("Time Series (5min)")]
        public Dictionary<string, TimeSeriesDataIntradayApiResponseDto> TimeSeries { get; set; }
    }
}
