using Microsoft.EntityFrameworkCore;

namespace AddressService.Database.Config
{
    public interface IConfigureDb
    {
        public void ConfigureDB(ModelBuilder modelBuilder);
    }
}
