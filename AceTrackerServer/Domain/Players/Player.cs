using Domain.Games;
using Domain.Shared.Enums;
using Domain.Users;

namespace Domain.Players;

public class Player
{
    public PlayerId PlayerId { get; private set; } = null!;
    public int GameId { get; private set; }
    public virtual Game Game { get; private set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public virtual User User { get; private set; } = null!;
    public PlayerScore PlayerScore { get; private set; } = new PlayerScore(0,0);
    public PlayerState PlayerState { get; private set; } = PlayerState.NotReady;

    public static Player? Create(Game game, User user)
    => new Player()
    {
        Game = game,
        User = user
    };

    public void SetScore(int score)
    {
        if (PlayerState is not PlayerState.Playing) return;

        var playerScore = new PlayerScore(score, Game.Stake);
        if (playerScore is null) return;

        PlayerScore = playerScore;
    }

    public void ChangeStateToPlaying()
    {
        if (PlayerState is PlayerState.NotReady) PlayerState = PlayerState.Playing;
    }
    public void ChangeStateToEnded()
    {
        if (PlayerState is PlayerState.Playing) PlayerState = PlayerState.Ended;
    }
}



