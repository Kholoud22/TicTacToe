using MediatR;
using TicTacToe.Application.Services.Contracts;

namespace TicTacToe.Application.Commands
{
    public class AddPlayersCommandHandler : IRequestHandler<AddPlayersCommand, Guid>
    {
        private readonly IGameBoardService _gameService;

        public AddPlayersCommandHandler(IGameBoardService gameService)
        {
            _gameService = gameService;
        }
        public async Task<Guid> Handle(AddPlayersCommand request, CancellationToken cancellationToken)
        {
            return await _gameService.StartNewGameWithNewPlayer(request.PlayerXUsername, request.PlayerOUsername);
        }
    }
}
