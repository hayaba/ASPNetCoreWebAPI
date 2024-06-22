using Microsoft.EntityFrameworkCore;

namespace kontaktpersoner.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<KontaktPerson> KontaktPersoner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");


        // Seed the database with some example data for testing purposes 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            KontaktPerson[] personerToSeed = new KontaktPerson[6];

            for (int i = 1; i <= 6; i++)
            {
                personerToSeed[i - 1] = new KontaktPerson
                {
                    KontaktId = i,
                    Navn = $"Person {i}",
                    Adresse = $"Adresse {i}",
                    Email = $"Email {i}",
                    Telefon = $"Telefon {i}"
                    };
            }
            modelBuilder.Entity<KontaktPerson>().HasData(personerToSeed);
        }
    }
}
