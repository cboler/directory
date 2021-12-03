using Microsoft.EntityFrameworkCore;

namespace PhoneDirectory.Models
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext(DbContextOptions<DirectoryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectoryEntry>()
                .HasData(new DirectoryEntry()
                {
                    Id = 1,
                    Name = "Joe Biden",
                    Address = "1600 Pennsylvania Avenue NW Washington, D.C. 20502",
                    PhoneNumber = "202-456-1414"
                },
                new DirectoryEntry()
                {
                    Id = 2,
                    Name = "Peter Griffin",
                    Address = "31 Spooner Street, Quahog, Rhode Island 00093 ",
                    PhoneNumber = "401-455-1155"
                },
                new DirectoryEntry()
                {
                    Id = 3,
                    Name = "Al Bundy",
                    Address = "9764 Jeopardy Lane, Chicago, Illinois 60007",
                    PhoneNumber = "773-555-2878"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<DirectoryEntry> DirectoryEntries { get; set; }
    }
}
