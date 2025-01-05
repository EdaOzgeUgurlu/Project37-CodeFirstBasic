using Microsoft.EntityFrameworkCore;

namespace Project37_CodeFirstBasic.Data
{
    public class PatikaFirstDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456eda;Database= PatikaCodeFirstDb4 ");
        }
    }
}
