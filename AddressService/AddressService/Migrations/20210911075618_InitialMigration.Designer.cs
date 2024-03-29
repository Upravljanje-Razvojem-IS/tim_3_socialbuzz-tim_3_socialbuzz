﻿// <auto-generated />
using System;
using AddressService.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressService.Migrations
{
    [DbContext(typeof(AddressServiceDatabase))]
    [Migration("20210911075618_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressService.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.HasIndex("ZipCode")
                        .IsUnique()
                        .HasFilter("[ZipCode] IS NOT NULL");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AddressService.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1454d5-b5dc-4017-811b-82ec57537300"),
                            Code = "381",
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = new Guid("c9c54d85-46f7-48dc-8371-ccf5d392b9e8"),
                            Code = "44",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = new Guid("2c138c56-302c-4455-ae7a-6eeee3c02f1e"),
                            Code = "49",
                            Name = "Germany"
                        },
                        new
                        {
                            Id = new Guid("1f3f6010-7656-4cf4-8fe1-e84aa7ec574a"),
                            Code = "33",
                            Name = "Frace"
                        },
                        new
                        {
                            Id = new Guid("e7858c5a-db1d-4b38-840e-530be6377785"),
                            Code = "34",
                            Name = "Spain"
                        },
                        new
                        {
                            Id = new Guid("5de5f72f-bcda-4362-851f-2e46de0e95dc"),
                            Code = "39",
                            Name = "Italy"
                        },
                        new
                        {
                            Id = new Guid("abae50dc-93a2-4be0-9309-56749039f7f8"),
                            Code = "387",
                            Name = "Bosnia and Herzegovina"
                        });
                });

            modelBuilder.Entity("AddressService.Models.City", b =>
                {
                    b.HasOne("AddressService.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
