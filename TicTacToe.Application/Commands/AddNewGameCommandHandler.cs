using MediatR;
using TicTacToe.Application.Services.Contracts;

namespace TicTacToe.Application.Commands
{
    public class AddNewGameCommandHandler : IRequestHandler<AddNewGameCommand, Guid>
    {
        private readonly IGameBoardService _gameService;

        public AddNewGameCommandHandler(IGameBoardService gameService)
        {
            _gameService = gameService;
        }
        public async Task<Guid> Handle(AddNewGameCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.StartNewGame(request.PlayerXId, request.PlayerOId);
        }
    }
}
