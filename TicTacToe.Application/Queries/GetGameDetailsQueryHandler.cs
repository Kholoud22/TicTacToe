using AutoMapper;
using MediatR;
using TicTacToe.Application.Dtos;
using TicTacToe.Application.Services.Contracts;
using TicTacToe.Domain.Exceptions;
using TicTacToe.Infrastructure.Repositories.Contracts;

namespace TicTacToe.Application.Queries
{
    public class GetGameDetailsQueryHandler : IRequestHandler<GetGameDetailsQuery, GetGameDetailsResponseDto>
    {
        private readonly IGameBoardService _gameService;
        private readonly IMapper _mapper;
        public GetGameDetailsQueryHandler(IGameBoardService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }
        public async Task<GetGameDetailsResponseDto> Handle(GetGameDetailsQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameService.GetGame(request.Id, true) ?? throw new NotFoundException(request.Id);
            return _mapper.Map<GetGameDetailsResponseDto>(game);
        }
    }
}
