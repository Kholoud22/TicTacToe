using TicTacToe.Domain.Exceptions;
using TicTacToe.Domain;
using TicTacToe.Infrastructure.Repositories.Contracts;
using TicTacToe.Domain.Enums;
using TicTacToe.Application.Services.Contracts;

namespace TicTacToe.Application.Services
{
    public class GameBoardService : IGameBoardService
    {
        private readonly IGameRepository _gameRepository;

        public GameBoardService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<Guid> StartNewGameWithNewPlayer(string playerXName, string playerOName)
        {
            // add new players
            var playerX = new Player(playerXName);
            var playerO = new Player(playerOName);

            // Create a new game and add it to the repository
            var game = new Game(playerX, playerO);
            await _gameRepository.Add(game);

            return game.Id;
        }

        public async Task<Guid> StartNewGame(Guid playerXId, Guid playerOId)
        {
            // Check if players exist and are eligible to start a new game
            var playerX = await _gameRepository.GetPlayerWithGames(playerXId);
            var playerO = await _gameRepository.GetPlayerWithGames(playerOId);

            if (playerX.XGames.Any(g => g.Status == GameStatus.Started) || playerO.OGames.Any(g => g.Status == GameStatus.Started))
            {
                throw new InvalidOperationException("A new game can't be started");
            }

            // Create a new game and add it to the repository
            var game = new Game(playerX, playerO);
            await _gameRepository.Add(game);

            return game.Id;
        }

        public async Task<Game?> GetGame(Guid gameId, bool includePlayers)
        {
            return await _gameRepository.GetById(gameId, includePlayers);
        }

        public async Task<Guid> UpdateGame(Guid gameId, Guid? winnerId)
        {
            // Retrieve the game from the repository
            var game = await _gameRepository.GetById(gameId, true) ?? throw new NotFoundException(gameId);

            if (game.Status == GameStatus.Completed)
            {
                throw new EditCompletedGameException(gameId);
            }

            if(winnerId.HasValue && game.PlayerXId != winnerId &&  game.PlayerOId != winnerId)
            {
                throw new NotFoundException(winnerId.Value);
            }

            // Update the game's winner and save changes
            game.SetWinnerId(winnerId);
            await _gameRepository.Update(game);

            return game.Id;
        }
    }

}
