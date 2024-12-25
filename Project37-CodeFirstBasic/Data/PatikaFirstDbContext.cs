using Project37_CodeFirstBasic.Data;
using Microsoft.EntityFrameworkCore;

namespace Project37_CodeFirstBasic.Data
{
    public class PatikaFirstDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456eda;Database=PatikaCodeFirstDb1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movies");
                entity.Property(x => x.Title).IsRequired().HasMaxLength(150);
                entity.Property(x => x.ReleaseYear).IsRequired();
            });

            modelBuilder.Entity<Movie>().HasData
                   (
                    new Movie() { Id = 1, Title = "Inception", Genre = "Science Fiction", ReleaseYear = 2010 },
                    new Movie() { Id = 2, Title = "The Godfather", Genre = "Crime", ReleaseYear = 1972 },
                    new Movie() { Id = 3, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008 },
                    new Movie() { Id = 4, Title = "Forrest Gump", Genre = "Drama", ReleaseYear = 1994 },
                    new Movie() { Id = 5, Title = "Coco", Genre = "Animation", ReleaseYear = 2017 }
                   );

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Games");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Platform).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Rating).IsRequired().HasColumnType("decimal(20,2)");
            });
            modelBuilder.Entity<Game>().HasData
                    (
                        new Game() { Id = 1, Name = "Red Dead Redemption 2", Platform = "PC" },
                        new Game() { Id = 2, Name = "The Last of Us Part II", Platform = "PlayStation" },
                        new Game() { Id = 3, Name = "Halo Infinite", Platform = "Xbox" },
                        new Game() { Id = 4, Name = "Super Mario Odyssey", Platform = "Nintendo Switch" },
                        new Game() { Id = 5, Name = "Cyberpunk 2077", Platform = "PC" }
                    );


        }
    }
}
