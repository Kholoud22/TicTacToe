using TicTacToe.Domain;

namespace TicTacToe.Infrastructure.Repositories.Contracts
{
    public interface IGameRepository
    {
        Task<Game?> GetById(Guid gameId, bool includePlayers);
        Task<Player> GetPlayerWithGames(Guid playerId);
        Task<Guid> Add(Game game);
        Task Update(Game game);
    }
}
