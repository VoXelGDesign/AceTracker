using Domain.Players;
using Domain.Shared.Enums;

namespace Domain.Games;

public class Game
{
    public GameId GameId { get; private set; } = null!;
    public GameStake GameStake { get; private set; } = null!;
    public ChipsAmount ChipsAmount { get; private set; } = null!;
    public virtual HashSet<Player> Players { get; private set; } = null!;
    public DateTime Date { get; set; }
    public GameState GameState { get; private set; } = GameState.Created;

    public static Game? Create(GameStake gameStake, ChipsAmount chipsAmount)
        => new Game
        {
            GameId = new GameId(Guid.NewGuid()),
            GameStake = gameStake,
            ChipsAmount = chipsAmount,
            Date = DateTime.Now,
        };
    
    public void AddPlayer(Player player)
    {
        if (GameState is not GameState.Created) return;
        Players.Add(player);
    }
    public void ChangeStateToActive()
    {
        if (GameState is GameState.Created) GameState = GameState.Active;
    }
    public void ChangeStateToEnded()
    {
        if (GameState is GameState.Active) GameState = GameState.Ended;
    }

}
