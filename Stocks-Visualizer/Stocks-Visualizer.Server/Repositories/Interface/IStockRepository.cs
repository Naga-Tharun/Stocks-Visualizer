using Stocks_Visualizer.Server.Models.Domain;

namespace Stocks_Visualizer.Server.Repositories.Interface
{
    public interface IStockRepository
    {
        Task<Stock> CreateAsync(Stock stock);

        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock?> GetAsync(Guid id);
    }
}
