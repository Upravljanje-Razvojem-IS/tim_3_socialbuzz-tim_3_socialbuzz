using LoggerService.Database.Config;
using LoggerService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LoggerService.Database
{
    public class LoggerServiceDatabase : DbContext
    {
        public LoggerServiceDatabase(DbContextOptions<LoggerServiceDatabase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var configClasses = typeof(LoggerServiceDatabase).Assembly.ExportedTypes
                .Where(x => typeof(IConfigureDb).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IConfigureDb>().ToList();

            configClasses.ForEach(config => config.ConfigureDB(modelBuilder));
        }
        public DbSet<Log> LogEntries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
