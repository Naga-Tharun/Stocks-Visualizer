using Stocks_Visualizer.Server.Models.Domain;

namespace Stocks_Visualizer.Server.Repositories.Interface
{
    public interface IStockRepositorycs
    {
        Task<Stock> CreateAsync(Stock stock);
    }
}
