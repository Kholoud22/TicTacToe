using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTacToe.Domain;

namespace TicTacToe.Infrastructure.EntityConfigurations
{
    public class GameEntityTypeConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.PlayerX)
                .WithMany(p => p.XGames)
                .HasForeignKey(p => p.PlayerXId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.PlayerO)
                .WithMany(p => p.OGames)
                .HasForeignKey(p => p.PlayerOId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
