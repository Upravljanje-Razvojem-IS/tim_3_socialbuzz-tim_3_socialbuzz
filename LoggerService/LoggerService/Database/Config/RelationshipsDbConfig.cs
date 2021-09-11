using LoggerService.Model;
using Microsoft.EntityFrameworkCore;

namespace LoggerService.Database.Config
{
    public class RelationshipsDbConfig : IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var log = modelBuilder.Entity<Log>();

            log.HasOne(l => l.User);
        }
    }
}
