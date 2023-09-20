using Microsoft.EntityFrameworkCore;
using TicTacToe.Domain;
using TicTacToe.Domain.Exceptions;
using TicTacToe.Infrastructure.Repositories.Contracts;

namespace TicTacToe.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameBoardsContext _context;

        public GameRepository(GameBoardsContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public async Task<Game?> GetById(Guid gameId, bool includePlayers)
        {
            var query = _context.Games.AsQueryable();
            if (includePlayers)
            {
                query = query.Include(p => p.PlayerX)
                            .Include(p => p.PlayerO);
            }
            return await query.FirstOrDefaultAsync(p => p.Id == gameId);
        }

        public async Task Update(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Player> GetPlayerWithGames(Guid playerId)
        {
            var player = await _context.Players
                .Include(p => p.OGames)
                .Include(p => p.XGames)
                .FirstOrDefaultAsync(p => p.Id == playerId)
                ?? throw new NotFoundException(playerId);

            return player;
        }
    }

}
