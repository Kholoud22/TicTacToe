using AutoMapper;
using TicTacToe.Application.Dtos;
using TicTacToe.Domain;

namespace TicTacToe.Application.Mappers
{
    public class GameMapping : Profile
    {
        public GameMapping() 
        {
            CreateMap<Game, GetGameDetailsResponseDto>()
                .ForMember(p => p.GameId, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.PlayerOId, opt => opt.MapFrom(p => p.PlayerOId))
                .ForMember(p => p.PlayerXId, opt => opt.MapFrom(p => p.PlayerXId))
                .ForMember(p => p.PlayerOUsername, opt => opt.MapFrom(p => p.PlayerO.Username))
                .ForMember(p => p.PlayerXTotalWins, opt => opt.MapFrom(p => p.PlayerX.Wins))
                .ForMember(p => p.PlayerXUsername, opt => opt.MapFrom(p => p.PlayerX.Username))
                .ForMember(p => p.PlayerOTotalWins, opt => opt.MapFrom(p => p.PlayerO.Wins))
                .ForMember(p => p.Status, opt => opt.MapFrom(p => p.Status));
        }
    }
}
