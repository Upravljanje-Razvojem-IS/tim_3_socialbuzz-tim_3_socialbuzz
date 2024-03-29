﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PostAggregatedService.DataLayer;

namespace PostAggregatedService.Migrations
{
    [DbContext(typeof(PostAggregatedDbContext))]
    [Migration("20210819200121_postaggregateddbmigration")]
    partial class postaggregateddbmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PostAggregatedService.Entities.PostAggregated", b =>
                {
                    b.Property<Guid>("PostAggregatedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfComments")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfDislikes")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfHearts")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfLikes")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSmileys")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfVisits")
                        .HasColumnType("int");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PostAggregatedId");

                    b.ToTable("PostAggregated");
                });
#pragma warning restore 612, 618
        }
    }
}
