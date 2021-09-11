using AddressService.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressService.Database.Config
{
    public static class RelationshipsConfigDb
    {
        public static void ConfigureDbRelationships(this ModelBuilder modelBuilder)
        {
            var city = modelBuilder.Entity<City>();
            city.HasOne(c => c.Country)
                .WithMany();
        }
    }
}
