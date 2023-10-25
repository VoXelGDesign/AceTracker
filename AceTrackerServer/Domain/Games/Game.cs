using Domain.Players;
using Domain.Shared.Enums;

namespace Domain.Games;

public class Game
{
    public GameId GameId { get; private set; } = null!;
    public GameStake GameStake { get; private set; } = null!;
    public int AmountOfChips { get; private set; }
    public virtual ICollection<Player> Players { get; private set; } = null!;
    public DateTime Date { get; set; }
    public GameState GameState { get; private set; } = GameState.Created;

    public void ChangeStateToActive()
    {
        if (GameState is GameState.Created) GameState = GameState.Active;
    }
    public void ChangeStateToEnded()
    {
        if (GameState is GameState.Active) GameState = GameState.Ended;
    }

}
