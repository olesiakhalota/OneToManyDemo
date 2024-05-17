using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Models;

namespace OneToManyDemo.Data
{
    public class SeedData
    {

        public static void AddRecords(ModelBuilder modelBuilder)
        {
            //seeding data
            modelBuilder.Entity<Auteur>().HasData(
                            new Auteur { AuteurId = 1 , Naam = "J.K. Rolling"},
                            new Auteur { AuteurId = 2 , Naam = "Stephen King"},
                            new Auteur { AuteurId = 3 , Naam = "J.R.R. Tolkien"},
                            new Auteur { AuteurId = 4 , Naam = "Dan Brown"}
                );

            modelBuilder.Entity<Boek>().HasData(
                new Boek { BoekId = 1, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 2, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 3, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 4, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 5, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 6, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 7, Titel = "De anvonturen van Code 1", AuteurId = 1 },
                new Boek { BoekId = 8, Titel = "De anvonturen van Code 1", AuteurId = 1 }
                );
            
        }
    }
}
