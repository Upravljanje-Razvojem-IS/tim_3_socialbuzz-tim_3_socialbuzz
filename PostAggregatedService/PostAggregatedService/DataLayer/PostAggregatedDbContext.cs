using Microsoft.EntityFrameworkCore;
using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.DataLayer
{
#pragma warning disable CS1591
    public class PostAggregatedDbContext : DbContext
    {
        public PostAggregatedDbContext(DbContextOptions<PostAggregatedDbContext> options) : base(options)

        {
        }

        public DbSet<PostAggregated> PostAggregated { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostAggregated>().HasData(
                new PostAggregated
                {
                    PostAggregatedId = Guid.Parse("d221da3e-f9d5-45d5-a44c-15479d3b7b21"),
                    PostId = Guid.Parse("71a1d81c-7fea-4e9a-bb29-541e165fc198"),
                    NumberOfComments = 10,
                    NumberOfDislikes = 5,
                    NumberOfHearts = 6,
                    NumberOfLikes = 10,
                    NumberOfSmileys = 1,
                    NumberOfVisits = 100
                }
                );
        }
    }
#pragma warning restore CS1591
}
