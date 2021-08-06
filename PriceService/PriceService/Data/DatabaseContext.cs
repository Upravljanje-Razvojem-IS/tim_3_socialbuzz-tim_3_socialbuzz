using Microsoft.EntityFrameworkCore;
using PriceService.Entities;

namespace PriceService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<PriceHistory> PriceHistories { get; set; }
    }
}
