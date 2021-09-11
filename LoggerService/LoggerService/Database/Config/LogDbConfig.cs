using LoggerService.Model;
using Microsoft.EntityFrameworkCore;

namespace LoggerService.Database.Config
{
    public class LogDbConfig : IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var log = modelBuilder.Entity<Log>();
            log.HasKey(l => l.Id);
            log.Property(l => l.Timestamp)
                .IsRequired()
                .ValueGeneratedOnAdd();
            log.OwnsOne(l => l.Response);
            log.OwnsOne(l => l.Request);
            log.OwnsOne(l => l.Error);
        }
    }
}
