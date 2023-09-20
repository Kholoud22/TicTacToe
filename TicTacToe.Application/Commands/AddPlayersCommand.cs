using MediatR;

namespace TicTacToe.Application.Commands
{
    public class AddPlayersCommand : IRequest<Guid>
    {
        public string PlayerXUsername { get; set; }
        public string PlayerOUsername { get; set; }
    }
}