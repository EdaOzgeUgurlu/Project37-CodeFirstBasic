using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace CodeFirst_Revize.Data
{
    public class UygulamaDbContext : DbContext
    {
        public DbSet<Gorev> Gorevler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456eda;Database=YapilacaklarDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Gorev>()
                .Property(x => x.Baslik)
                .HasMaxLength(400);

            modelBuilder.Entity<Gorev>().HasData(
                new Gorev() { Id = 1, Baslik = "Tatile çık", Yapildi = false },
                new Gorev() { Id = 2, Baslik = "Evlen", Yapildi = false },
                new Gorev() { Id = 3, Baslik = "Saygınlık kazan", Yapildi = true },
                new Gorev() { Id = 4, Baslik = "İşe Gir", Yapildi = true }
                );
        }
    }
}
