using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using Stocks_Visualizer.Server.Models.Domain;

namespace Stocks_Visualizer.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Stock> Stocks { get; set; }
    }
}
