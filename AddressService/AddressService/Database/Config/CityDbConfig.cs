using AddressService.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressService.Database.Config
{
    public class CityDbConfig : IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var city = modelBuilder.Entity<City>();
            city.HasKey(c => c.Id);
            city.Property(c => c.Name)
                .HasMaxLength(300);
            city.HasIndex(c => c.Name)
                .IsUnique();
            city.Property(c => c.ZipCode)
                .HasMaxLength(200);
            city.HasIndex(c => c.ZipCode)
                .IsUnique();
        }
    }
}
