using Microsoft.EntityFrameworkCore;
using OneToManyDemo.Models;

namespace OneToManyDemo.Data
{
    public class BoekenDBContext : DbContext
    {
        public BoekenDBContext(DbContextOptions<BoekenDBContext> options) : base(options)
        {
                
        }

        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Boek> Boeks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //configuration ONE - MANY relation  // class van EF - provides simple IP (fluent)
        {
           base.OnModelCreating(modelBuilder);

            //configure Auteur     entity = сущность
            modelBuilder.Entity<Auteur>()
                .HasMany(a => a.Boeken)   //fluent API // 1 TO MANY RELATION
                .WithOne(b => b.Auteur)
                .HasForeignKey(b => b.AuteurId)
                .OnDelete(DeleteBehavior.NoAction);

            //configure Boek
            modelBuilder.Entity<Boek>()
                .HasKey(b => b.BoekId);
            modelBuilder.Entity<Boek>()
                .HasOne(b => b.Auteur)  //1 TO MANY RELATION
                .WithMany(a => a.Boeken)
                .HasForeignKey(b => b.AuteurId)
                .OnDelete(DeleteBehavior.NoAction);
              


            SeedData.AddRecords(modelBuilder);
        }
    }
}
