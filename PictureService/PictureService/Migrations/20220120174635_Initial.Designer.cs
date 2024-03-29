﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PictureService.Data;

namespace PictureService.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220120174635_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("PictureService.Entities.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("PictureService.Entities.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pictures");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Picture");
                });

            modelBuilder.Entity("PictureService.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("PictureService.Entities.PostPicture", b =>
                {
                    b.HasBaseType("PictureService.Entities.Picture");

                    b.Property<string>("PictureType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("PostId");

                    b.HasDiscriminator().HasValue("PostPicture");
                });

            modelBuilder.Entity("PictureService.Entities.ProfilePicture", b =>
                {
                    b.HasBaseType("PictureService.Entities.Picture");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("SetAsProfilePicture")
                        .HasColumnType("datetime2");

                    b.HasIndex("OwnerId")
                        .IsUnique()
                        .HasFilter("[OwnerId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("ProfilePicture");
                });

            modelBuilder.Entity("PictureService.Entities.PostPicture", b =>
                {
                    b.HasOne("PictureService.Entities.Post", "Post")
                        .WithMany("postPictures")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("PictureService.Entities.ProfilePicture", b =>
                {
                    b.HasOne("PictureService.Entities.Owner", "Owner")
                        .WithOne("ProfilePicture")
                        .HasForeignKey("PictureService.Entities.ProfilePicture", "OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("PictureService.Entities.Owner", b =>
                {
                    b.Navigation("ProfilePicture");
                });

            modelBuilder.Entity("PictureService.Entities.Post", b =>
                {
                    b.Navigation("postPictures");
                });
#pragma warning restore 612, 618
        }
    }
}
