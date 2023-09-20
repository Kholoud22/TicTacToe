using TicTacToe.Application.Commands;
using TicTacToe.Application.Queries;
using TicTacToe.Domain.Enums;
using TicTacToe.Domain.Exceptions;

namespace TicTacToe.Test.IntegrationTests
{
    public class AddAndSaveGameCommandTests : ApplicationTestBase
    {
        [Fact]
        public async Task SaveAndAddNewGameTest()
        {
            var fakeId = Guid.NewGuid();
            var fakeQuery = new GetGameDetailsQuery(fakeId);
            var ex = await Assert.ThrowsAsync<NotFoundException>(async () => await SendAsync(fakeQuery));
            Assert.Equal($"Id: {fakeId} not found", ex.Message);

            var gameId = await CreateGame();
            Assert.NotNull(gameId.ToString());

            var query = new GetGameDetailsQuery(gameId);
            var game = await SendAsync(query);
            Assert.NotNull(game);
            Assert.Equal(gameId, game.GameId);
            Assert.Equal(GameStatus.Started, game.Status);
            Assert.Equal(0, game.PlayerXTotalWins);
            Assert.Equal(0, game.PlayerOTotalWins);

            var command = new SaveGameCommand
            {
                GameId = gameId,
                WinnerId = fakeId
            };
            var saveEx = await Assert.ThrowsAsync<NotFoundException>(async () => await SendAsync(command));
            Assert.Equal($"Id: {fakeId} not found", saveEx.Message);

            command.WinnerId = null;
            await SendAsync(command);
            game = await SendAsync(query);
            Assert.NotNull(game);
            Assert.Equal(GameStatus.Completed, game.Status);
            Assert.Equal(0, game.PlayerXTotalWins);
            Assert.Equal(0, game.PlayerOTotalWins);
        }

        [Fact]
        public async Task SaveGameCommandTest()
        {
            var gameId = await CreateGame();
            var query = new GetGameDetailsQuery(gameId);
            var game = await SendAsync(query);

            var command = new SaveGameCommand()
            {
                GameId = gameId,
                WinnerId = game.PlayerOId
            };
            await SendAsync(command);

            game = await SendAsync(query);
            Assert.NotNull(game);
            Assert.Equal(GameStatus.Completed, game.Status);
            Assert.Equal(0, game.PlayerXTotalWins);
            Assert.Equal(1, game.PlayerOTotalWins);

            command.WinnerId = Guid.Empty;
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () => await SendAsync(command));
            Assert.Equal("Can't edit a completed game", ex.Message);
        }

        [Fact]
        public async Task AddNewGameWithExistingPlayersTest()
        {
            var gameId = await CreateGame();
            var query = new GetGameDetailsQuery(gameId);
            var game = await SendAsync(query);

            var command = new AddNewGameCommand()
            {
                PlayerOId = game.PlayerOId,
                PlayerXId = game.PlayerXId,
            };
            var ex = await Assert.ThrowsAsync<InvalidOperationException>(async () => await SendAsync(command));
            Assert.Equal("A new game can't be started", ex.Message);

            var saveCommand = new SaveGameCommand
            {
                GameId = gameId
            };
            await SendAsync(saveCommand);

            gameId = await SendAsync(command);
            query = new GetGameDetailsQuery(gameId);
            game = await SendAsync(query);

            Assert.NotNull(game);
            Assert.Equal(GameStatus.Started, game.Status);
        }
        private async Task<Guid> CreateGame()
        {
            var command = new AddPlayersCommand()
            {
                PlayerXUsername = "Xusername",
                PlayerOUsername = "OuserName",
            };

            return await SendAsync(command);
        }
    }
}