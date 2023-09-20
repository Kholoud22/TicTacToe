using TicTacToe.Domain.Enums;

namespace TicTacToe.Application.Dtos
{
    public class GetGameDetailsResponseDto
    {
        public Guid GameId { get; set; }
        public Guid PlayerOId { get; set; }
        public string PlayerOUsername { get; set; }
        public int PlayerOTotalWins { get; set; }
        public Guid PlayerXId { get; set;}
        public string PlayerXUsername { get; set;}
        public int PlayerXTotalWins { get; set; }
        public GameStatus Status { get; set; }
    }
}
