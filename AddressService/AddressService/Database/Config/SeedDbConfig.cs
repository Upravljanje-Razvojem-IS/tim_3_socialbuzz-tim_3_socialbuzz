using AddressService.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AddressService.Database.Config
{
    public static class SeedDbConfig
    {
        public static void SeedDb(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Serbia",
                        Code = "381"
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "United Kingdom",
                        Code = "44"
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Germany",
                        Code = "49"
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Frace",
                        Code = "33"
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Spain",
                        Code = "34"
                    },
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Italy",
                        Code = "39"
                    }, 
                    new Country
                    {
                        Id = Guid.NewGuid(),
                        Name = "Bosnia and Herzegovina",
                        Code = "387"
                    }
                );
        }
    }
}
