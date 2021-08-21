using Microsoft.EntityFrameworkCore;
using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.DataLayer
{
#pragma warning disable CS1591
    public class ReactionDbContext : DbContext
    {
        public ReactionDbContext(DbContextOptions<ReactionDbContext> options) : base(options)
        {
        }

        public DbSet<ReactionType> ReactionTypes { get; set; }
        public DbSet<Reaction> Reaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReactionType>().HasData(
               new ReactionType
               {
                   ReactionTypeID = Guid.Parse("77be3bf1-5df2-4fcb-a89a-dfebc0b69b1f"),
                   ReactionTypeName = "Like",
                   ReactionTypeImage = "likeImage.png"
               },
                new ReactionType
                {
                    ReactionTypeID = Guid.Parse("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                    ReactionTypeName = "Dislike",
                    ReactionTypeImage = "dislikeImage.png"
                }
                );
            modelBuilder.Entity<Reaction>().HasData(
               new Reaction
               {
                   ReactionId = Guid.Parse("d06e3c0a-0291-4dfd-b99f-07d0f6aa4501"),
                   ReactionTypeId = Guid.Parse("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                   Day = 12,
                   Month = 4,
                   Year = 2008,
                   UserId = Guid.Parse("b5104b9c-c94d-4a84-9aea-13a615358dab")
               },
                new Reaction
                {
                    ReactionId = Guid.Parse("93f498c9-4eae-42b5-b9ef-f98e53fd5169"),
                    ReactionTypeId = Guid.Parse("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                    Day = 15,
                    Month = 5,
                    Year = 2005,
                    UserId = Guid.Parse("fe5bd367-0a45-44cb-8299-faa6fe2e632a")
                }
                );
        }
    }
#pragma warning restore CS1591
}
