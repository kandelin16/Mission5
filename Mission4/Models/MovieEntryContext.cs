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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    EntryID = 1,
                    Category = "Action/Adventure",
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13"
                },
                new MovieEntry
                {
                    EntryID = 2,
                    Category = "Comedy",
                    Title = "Groundhog Day",
                    Year = 1993,
                    Director = "Harold Ramis",
                    Rating = "PG"
                },
                new MovieEntry
                {
                    EntryID = 3,
                    Category = "Comedy",
                    Title = "Back To The Future",
                    Year = 1985,
                    Director = "Robert Zemeckis",
                    Rating = "PG"
                }
            );
            ;
        }
    }
}
