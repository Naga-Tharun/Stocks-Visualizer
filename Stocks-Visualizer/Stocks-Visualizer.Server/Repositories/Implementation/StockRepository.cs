﻿using Microsoft.EntityFrameworkCore;
using Stocks_Visualizer.Server.Data;
using Stocks_Visualizer.Server.Models.Domain;
using Stocks_Visualizer.Server.Repositories.Interface;

namespace Stocks_Visualizer.Server.Repositories.Implementation
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext dbContext;
        public StockRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Stock> CreateAsync(Stock stock)
        {
            await dbContext.Stocks.AddAsync(stock);
            await dbContext.SaveChangesAsync();

            return stock;
        }

        public async Task<IEnumerable<Stock>> GetAllAsync()
        {
            return await dbContext.Stocks.Include(x=> x.TimeSeries).ToListAsync();
        }

        public async Task<Stock?> GetAsync(Guid id)
        {
            return await dbContext.Stocks.Include(x=>x.TimeSeries).FirstOrDefaultAsync(x=> x.Id == id);
        }
    }
}
