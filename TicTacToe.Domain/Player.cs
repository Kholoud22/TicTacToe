using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Domain;
public class Player
{
    public Player(string userName)
    {
        Id = Guid.NewGuid();
        SetUsername(userName);
    }
    private Player()
    {
    }
    public Guid Id { get; private set; }

    [Required]
    public string Username { get; private set; }

    public int Wins { get; private set; }

    public ICollection<Game> XGames { get; private set; }
    public ICollection<Game> OGames { get; private set; }

    public Player SetUsername(string username)
    {
        Username = username;
        return this;
    }

    public void SetWins()
    {
        ++Wins;
    }
}
