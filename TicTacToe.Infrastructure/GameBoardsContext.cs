using Microsoft.EntityFrameworkCore;
using TicTacToe.Domain;
using TicTacToe.Infrastructure.EntityConfigurations;

namespace TicTacToe.Infrastructure
{
    public class GameBoardsContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public GameBoardsContext()
        {
        }

        public GameBoardsContext(DbContextOptions<GameBoardsContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("GameBoardsDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlayerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GameEntityTypeConfiguration());
        }
    }
}