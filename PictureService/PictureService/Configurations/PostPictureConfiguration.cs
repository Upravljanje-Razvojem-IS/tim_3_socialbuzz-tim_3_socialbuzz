using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PictureService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PictureService.Configurations
{
    public class PostPictureConfiguration : IEntityTypeConfiguration<PostPicture>
    {
        public void Configure(EntityTypeBuilder<PostPicture> builder)
        {
           


            builder.HasOne(x => x.Post)
                .WithMany(x => x.postPictures)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
