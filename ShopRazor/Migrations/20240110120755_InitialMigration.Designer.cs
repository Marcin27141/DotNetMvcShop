﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopRazor.Models.Database;

#nullable disable

namespace ShopRazor.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20240110120755_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopRazor.Database.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("ExpiryDate")
                        .HasColumnType("date");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ac6e201e-a4d1-402e-bd2b-0389c802c6ad"),
                            CategoryId = new Guid("59aa8dfe-04e7-4a4b-8618-10c003c69824"),
                            ExpiryDate = new DateOnly(2023, 12, 20),
                            ImagePath = "/image/no_image.jpg",
                            Name = "Chocolate bar",
                            Price = 2.34m
                        },
                        new
                        {
                            Id = new Guid("38a77687-d00c-4085-9cce-d2a92e759e23"),
                            CategoryId = new Guid("a5ed66e8-0c88-4690-a5b1-4192938e3584"),
                            ExpiryDate = new DateOnly(2033, 12, 20),
                            ImagePath = "/image/no_image.jpg",
                            Name = "Bird cage",
                            Price = 47.29m
                        },
                        new
                        {
                            Id = new Guid("7a86f1ad-c5b8-49fd-920e-057a7c7ea42e"),
                            CategoryId = new Guid("60a0c724-b255-43fe-88c2-4148385cd1a6"),
                            ExpiryDate = new DateOnly(2034, 7, 7),
                            ImagePath = "/image/no_image.jpg",
                            Name = "Flute coursebook",
                            Price = 10.00m
                        },
                        new
                        {
                            Id = new Guid("37c04cea-2308-43ff-b9e1-e6cf73c228ea"),
                            CategoryId = new Guid("198722dc-c10a-4842-acb1-974721c6f24a"),
                            ExpiryDate = new DateOnly(2043, 1, 1),
                            ImagePath = "/image/no_image.jpg",
                            Name = "Gloomhaven",
                            Price = 80.99m
                        });
                });

            modelBuilder.Entity("ShopRazor.Database.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsPromo")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47242800-2bdd-4b64-a508-0890e84adf8e"),
                            IsPromo = false,
                            Name = "Others"
                        },
                        new
                        {
                            Id = new Guid("59aa8dfe-04e7-4a4b-8618-10c003c69824"),
                            IsPromo = false,
                            Name = "Food"
                        },
                        new
                        {
                            Id = new Guid("198722dc-c10a-4842-acb1-974721c6f24a"),
                            IsPromo = false,
                            Name = "Board Game"
                        },
                        new
                        {
                            Id = new Guid("551257be-8a7f-48bc-8363-188a4cc1f5c2"),
                            IsPromo = false,
                            Name = "Computer Game"
                        },
                        new
                        {
                            Id = new Guid("0b68c20d-d1db-42a4-ba38-655c2ffe3d77"),
                            IsPromo = false,
                            Name = "Book"
                        },
                        new
                        {
                            Id = new Guid("057bb5d8-5b20-4a99-a328-8b971274b822"),
                            IsPromo = false,
                            Name = "Furniture"
                        },
                        new
                        {
                            Id = new Guid("60a0c724-b255-43fe-88c2-4148385cd1a6"),
                            IsPromo = false,
                            Name = "Music"
                        },
                        new
                        {
                            Id = new Guid("0b0d0723-76fd-4d1c-a715-a70ea6063450"),
                            IsPromo = false,
                            Name = "School"
                        },
                        new
                        {
                            Id = new Guid("a5ed66e8-0c88-4690-a5b1-4192938e3584"),
                            IsPromo = false,
                            Name = "Animals"
                        });
                });

            modelBuilder.Entity("ShopRazor.Database.Article", b =>
                {
                    b.HasOne("ShopRazor.Database.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
