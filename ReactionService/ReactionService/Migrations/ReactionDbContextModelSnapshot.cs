﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactionService.DataLayer;

namespace ReactionService.Migrations
{
    [DbContext(typeof(ReactionDbContext))]
    partial class ReactionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReactionService.Entities.Reaction", b =>
                {
                    b.Property<Guid>("ReactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<Guid>("ReactionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ReactionId");

                    b.ToTable("Reaction");

                    b.HasData(
                        new
                        {
                            ReactionId = new Guid("d06e3c0a-0291-4dfd-b99f-07d0f6aa4501"),
                            Day = 12,
                            Month = 4,
                            ReactionTypeId = new Guid("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                            UserId = new Guid("b5104b9c-c94d-4a84-9aea-13a615358dab"),
                            Year = 2008
                        },
                        new
                        {
                            ReactionId = new Guid("93f498c9-4eae-42b5-b9ef-f98e53fd5169"),
                            Day = 15,
                            Month = 5,
                            ReactionTypeId = new Guid("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                            UserId = new Guid("fe5bd367-0a45-44cb-8299-faa6fe2e632a"),
                            Year = 2005
                        });
                });

            modelBuilder.Entity("ReactionService.Entities.ReactionType", b =>
                {
                    b.Property<Guid>("ReactionTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReactionTypeImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReactionTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReactionTypeID");

                    b.ToTable("ReactionTypes");

                    b.HasData(
                        new
                        {
                            ReactionTypeID = new Guid("77be3bf1-5df2-4fcb-a89a-dfebc0b69b1f"),
                            ReactionTypeImage = "likeImage.png",
                            ReactionTypeName = "Like"
                        },
                        new
                        {
                            ReactionTypeID = new Guid("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                            ReactionTypeImage = "dislikeImage.png",
                            ReactionTypeName = "Dislike"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
