﻿// <auto-generated />
using System;
using GenericEcommerce.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GenericEcommerce.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenericEcommerce.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GenericEcommerce.Models.Game", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameId"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<int?>("CategoryId1")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ImageURLThumbnail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("GameId");

                    b.HasIndex("CategoryId1");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GenericEcommerce.Models.Game", b =>
                {
                    b.HasOne("GenericEcommerce.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GenericEcommerce.Models.Category", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
