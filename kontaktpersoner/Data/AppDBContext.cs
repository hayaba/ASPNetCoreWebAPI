using Microsoft.EntityFrameworkCore;

namespace kontaktpersoner.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<kontaktPerson> KontaktPersoner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");


        // Seed the database with some example data for testing purposes 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            kontaktPerson[] personerToSeed = new kontaktPerson[6];

            for (int i = 0; i < personerToSeed.Length; i++)
            {

            }
        }
    }
}
