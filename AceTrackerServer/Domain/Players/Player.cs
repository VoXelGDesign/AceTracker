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
    public int Score { get; private set; }
    public PlayerState PlayerState { get; private set; } = PlayerState.NotReady;

    public void ChangeStateToPlaying()
    {
        if (PlayerState == PlayerState.NotReady) { PlayerState = PlayerState.Playing; }
    }
    public void ChangeStateToEnded()
    {
        if (PlayerState == PlayerState.Playing) { PlayerState = PlayerState.Ended; }
    }
}



