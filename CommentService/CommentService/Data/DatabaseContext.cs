using CommentService.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommentService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}
