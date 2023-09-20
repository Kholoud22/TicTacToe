using MediatR;

namespace TicTacToe.Application.Commands
{
    public class AddNewGameCommand : IRequest<Guid>
    {
        public Guid PlayerXId { get; set; }
        public Guid PlayerOId { get; set; }
    }
}