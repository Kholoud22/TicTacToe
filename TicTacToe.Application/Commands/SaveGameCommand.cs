using MediatR;

namespace TicTacToe.Application.Commands
{
    public class SaveGameCommand : IRequest<Guid>
    {
        public Guid GameId { get; set; }
        public Guid? WinnerId { get; set; }
    }
}