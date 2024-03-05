using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stocks_Visualizer.Server.Models.Domain;

namespace Stocks_Visualizer.Server.Models.DTO
{
    public class MetaDataApiResponseDto
    {
        [JsonProperty("1. Information")]
        public string Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public DateTime LastRefreshed { get; set; }

        [JsonProperty("4. Output Size")]
        public string OutputSize { get; set; }

        [JsonProperty("5. Time Zone")]
        public string TimeZone { get; set; }
    }

    public class TimeSeriesDataApiResponseDto
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
        public int Volume { get; set; }
    }

    public class StockApiResponseDto
    {
        [JsonProperty("Meta Data")]
        public MetaDataApiResponseDto MetaData { get; set; }

        [JsonExtensionData]
        private Dictionary<string, JToken> additionalData;

        [JsonIgnore]
        public Dictionary<string, TimeSeriesDataApiResponseDto> TimeSeries
        {
            get
            {
                if (additionalData != null)
                {
                    var timeSeries = new Dictionary<string, TimeSeriesDataApiResponseDto>();

                    foreach (var entry in additionalData)
                    {
                        string timeFrame = entry.Key;

                        var entryValues = entry.Value as JObject;

                        foreach (var entryValue in entryValues)
                        {
                            timeSeries.Add(entryValue.Key, entryValue.Value.ToObject<TimeSeriesDataApiResponseDto>());
                        }
                    }

                    return timeSeries;
                }

                return null;
            }
        }
    }
}
