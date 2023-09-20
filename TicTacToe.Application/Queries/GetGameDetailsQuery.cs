using MediatR;
using TicTacToe.Application.Dtos;

namespace TicTacToe.Application.Queries
{
    public class GetGameDetailsQuery : IRequest<GetGameDetailsResponseDto>
    {
        public GetGameDetailsQuery(Guid gameId)
        {
            Id = gameId;
        }
        public Guid Id { get; private set; }
    }
}
