using DeliveryService.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeliveryService.API.Database
{
    public class DeliveryServiceDbContext : DbContext
    {
        public DeliveryServiceDbContext()
        {
        }

        public DeliveryServiceDbContext(DbContextOptions<DeliveryServiceDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PriceDistance> PriceDistances { get; set; }
        public virtual DbSet<WeightRange> WeightRanges { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

    }
}
