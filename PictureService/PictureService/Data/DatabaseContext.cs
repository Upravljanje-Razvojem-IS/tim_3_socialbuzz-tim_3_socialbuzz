using Microsoft.EntityFrameworkCore;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostPicture> PostPictures { get; set; }
        public virtual DbSet<ProfilePicture> ProfilePictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }

    }
}
