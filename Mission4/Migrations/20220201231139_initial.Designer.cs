﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission4.Models;

namespace Mission4.Migrations
{
    [DbContext(typeof(MovieEntryContext))]
    [Migration("20220201231139_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Mission4.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Action/Adventure"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Romance"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Documentary"
                        });
                });

            modelBuilder.Entity("Mission4.Models.MovieEntry", b =>
                {
                    b.Property<int>("EntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<short>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("MovieEntries");

                    b.HasData(
                        new
                        {
                            EntryID = 1,
                            CategoryID = 1,
                            Director = "George Lucas",
                            Edited = false,
                            Rating = "PG-13",
                            Title = "Star Wars Episode III: Revenge of the Sith",
                            Year = (short)2005
                        },
                        new
                        {
                            EntryID = 2,
                            CategoryID = 2,
                            Director = "Harold Ramis",
                            Edited = false,
                            Rating = "PG",
                            Title = "Groundhog Day",
                            Year = (short)1993
                        },
                        new
                        {
                            EntryID = 3,
                            CategoryID = 2,
                            Director = "Robert Zemeckis",
                            Edited = false,
                            Rating = "PG",
                            Title = "Back To The Future",
                            Year = (short)1985
                        });
                });

            modelBuilder.Entity("Mission4.Models.MovieEntry", b =>
                {
                    b.HasOne("Mission4.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}