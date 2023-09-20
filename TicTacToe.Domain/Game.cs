using TicTacToe.Domain.Enums;
using TicTacToe.Domain.Exceptions;

namespace TicTacToe.Domain
{
    public class Game
    {
        public Game(Player playerX, Player playerO)
        {
            Id = Guid.NewGuid();
            Status = GameStatus.Started;
            SetPlayerO(playerO)
                .SetPlayerX(playerX);
        }

        private Game()
        {
        }
        public Guid Id { get; private set; }

        public Guid PlayerXId { get; private set; }

        public Player PlayerX { get; private set; }

        public Guid PlayerOId { get; private set; }

        public Player PlayerO { get; private set; }

        public Guid WinnerId { get; private set; }

        public GameStatus Status { get; private set; }

        public Game SetPlayerX(Player playerX)
        {
            PlayerX = playerX;
            return this;
        }

        public Game SetPlayerO(Player playerO)
        {
            PlayerO = playerO;
            return this;
        }

        public void SetWinnerId(Guid? winnerId)
        {
            if (winnerId.HasValue && winnerId != Guid.Empty)
            {
                var winningPlayer = winnerId == PlayerOId ? PlayerO : PlayerX;
                winningPlayer.SetWins();

                WinnerId = winnerId.Value;
            }

            Status = GameStatus.Completed;
        }
    }
}
