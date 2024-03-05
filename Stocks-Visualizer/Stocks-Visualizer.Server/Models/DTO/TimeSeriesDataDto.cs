namespace Stocks_Visualizer.Server.Models.DTO
{
    public class TimeSeriesDataDto
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Close { get; set; }

        public int Volume { get; set; }
    }
}
