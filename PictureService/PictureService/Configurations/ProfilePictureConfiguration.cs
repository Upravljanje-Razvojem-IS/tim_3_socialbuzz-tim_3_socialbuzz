using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Configurations
{
    public class ProfilePictureConfiguration : IEntityTypeConfiguration<ProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ProfilePicture> builder)
        {

          

            builder.HasOne(x => x.Owner)
                .WithOne(x => x.ProfilePicture)
                .HasForeignKey<ProfilePicture>(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
