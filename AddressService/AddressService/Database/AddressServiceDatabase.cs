using AddressService.Database.Config;
using AddressService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AddressService.Database
{
    public class AddressServiceDatabase : DbContext
    {
        public AddressServiceDatabase(DbContextOptions<AddressServiceDatabase> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var configClasses = typeof(AddressServiceDatabase).Assembly.ExportedTypes
               .Where(x => typeof(IConfigureDb).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
               .Select(Activator.CreateInstance).Cast<IConfigureDb>().ToList();

            configClasses.ForEach(config => config.ConfigureDB(modelBuilder));

            modelBuilder.ConfigureDbRelationships();
            modelBuilder.SeedDb();
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
