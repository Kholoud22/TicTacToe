using TicTacToe.Application.Dtos;
using TicTacToe.Domain;

namespace TicTacToe.Application.Services.Contracts
{
    public interface IGameBoardService
    {
        Task<Game?> GetGame(Guid gameId, bool includePlayers);
        Task<Guid> StartNewGameWithNewPlayer(string playerXName, string playerOName);
        Task<Guid> StartNewGame(Guid playerXId, Guid playerOId);
        Task<Guid> UpdateGame(Guid gameId, Guid? winnerId);
    }
}
