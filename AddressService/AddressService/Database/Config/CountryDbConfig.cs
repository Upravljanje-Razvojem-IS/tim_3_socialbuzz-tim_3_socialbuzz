using AddressService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressService.Database.Config
{
    public class CountryDbConfig : IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var country = modelBuilder.Entity<Country>();
            country.HasIndex(c => c.Id);
            country.Property(c => c.Name)
                .HasMaxLength(200);
            country.HasIndex(c => c.Name)
                .IsUnique();
            country.Property(c => c.Code)
                .HasMaxLength(10);
            country.HasIndex(c => c.Code)
                .IsUnique();
        }
    }
}
