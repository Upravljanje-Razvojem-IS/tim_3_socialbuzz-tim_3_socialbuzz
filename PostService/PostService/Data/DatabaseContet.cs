using Microsoft.EntityFrameworkCore;
using PostService.Entities;

namespace PostService.Data
{
    public class DatabaseContet : DbContext
    {
        public DatabaseContet()
        {

        }

        public DatabaseContet(DbContextOptions<DatabaseContet> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<PostPicture> Pictures { get; set; }

    }
}
