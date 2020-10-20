﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCC.Candle.Data;

namespace TCC.Candle.Data.Migrations
{
    [DbContext(typeof(CandleContext))]
    [Migration("20201020094820_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCC.Candle.Data.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biography");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<DateTime?>("DateOfDeath");

                    b.Property<string>("ImgUrl");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<string>("ISBN13");

                    b.Property<string>("ImgUrl");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Pages");

                    b.Property<DateTime>("Released");

                    b.Property<Guid>("ShelfId");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.Property<Guid?>("VolumeId");

                    b.Property<int>("language");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.HasIndex("VolumeId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.BookAuthor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AuthorId");

                    b.Property<Guid>("BookId");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BookId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("Modified");

                    b.Property<int>("Rate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Shelf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<Guid>("LibraryId");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("LibraryId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("TagName");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.TaggedBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BookId");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Order");

                    b.Property<Guid?>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("TagId");

                    b.ToTable("TaggedBooks");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Volume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Description");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("ShelfId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Book", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Shelf", "Shelf")
                        .WithMany("Books")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCC.Candle.Data.Entities.Volume", "Volume")
                        .WithMany("Books")
                        .HasForeignKey("VolumeId");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.BookAuthor", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCC.Candle.Data.Entities.Book", "Book")
                        .WithMany("Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Review", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Shelf", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Library", "Library")
                        .WithMany("Shelves")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Tag", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Library", "Library")
                        .WithMany()
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.TaggedBook", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Book", "Book")
                        .WithMany("Tags")
                        .HasForeignKey("BookId");

                    b.HasOne("TCC.Candle.Data.Entities.Tag", "Tag")
                        .WithMany("Books")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("TCC.Candle.Data.Entities.Volume", b =>
                {
                    b.HasOne("TCC.Candle.Data.Entities.Shelf", "Shelf")
                        .WithMany("Volumes")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}