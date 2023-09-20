using MediatR;
using TicTacToe.Application.Services.Contracts;
using TicTacToe.Infrastructure.Repositories.Contracts;

namespace TicTacToe.Application.Commands
{
    public class SaveGameCommandHandler : IRequestHandler<SaveGameCommand, Guid>
    {
        private readonly IGameBoardService _gameService;

        public SaveGameCommandHandler(IGameBoardService gameService)
        {
            _gameService = gameService;
        }
        public async Task<Guid> Handle(SaveGameCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.UpdateGame(request.GameId, request.WinnerId);
        }
    }
}
