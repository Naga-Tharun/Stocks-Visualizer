namespace Stocks_Visualizer.Server.Models.DTO
{
    public class StockViewDto
    {
        public StockViewDto() {
            this.open = new List<float>();
            this.close = new List<float>();
            this.high = new List<float>();
            this.low = new List<float>();
            this.openDate = new List<DateTime>();
        }
        public List<float> open {  get; set; }
        public List<float> close { get; set; }
        public List<float> high { get; set; }
        public List<float> low { get; set; }
        public List<DateTime> openDate { get; set; }
    }
}
