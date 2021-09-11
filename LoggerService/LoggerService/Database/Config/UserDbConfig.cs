using LoggerService.Model;
using Microsoft.EntityFrameworkCore;

namespace LoggerService.Database.Config
{
    public class UserDbConfig : IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder)
        {
            var user = modelBuilder.Entity<User>();

            user.HasKey(u => u.Id);
            user.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(300);
            user.HasIndex(u => u.Email)
                .IsUnique();
            user.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
