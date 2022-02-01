using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class MovieEntryContext : DbContext
    {
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base (options)
        {

        }

        public DbSet<MovieEntry> MovieEntries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Action/Adventure"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Romance"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Documentary"
                }
                );
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    EntryID = 1,
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13",
                    CategoryID = 1
                },
                new MovieEntry
                {
                    EntryID = 2,
                    Title = "Groundhog Day",
                    Year = 1993,
                    Director = "Harold Ramis",
                    Rating = "PG",
                    CategoryID = 2
                },
                new MovieEntry
                {
                    EntryID = 3,
                    Title = "Back To The Future",
                    Year = 1985,
                    Director = "Robert Zemeckis",
                    Rating = "PG",
                    CategoryID = 2
                }
            );
            ;
        }
    }
}
