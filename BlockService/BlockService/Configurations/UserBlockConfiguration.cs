using BlockService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockService.Configurations
{
    public class UserBlockConfiguration : IEntityTypeConfiguration<UserBlock>
    {
        public void Configure(EntityTypeBuilder<UserBlock> builder)
        {
            builder.HasOne(x => x.BlockedUser)
                .WithMany(x => x.BlockedUsers)
                .HasForeignKey(x => x.BlockedId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.User)
                .WithMany(x => x.BlockerUsers)
                .HasForeignKey(x => x.BlockerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
