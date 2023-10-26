namespace Domain.Games;

public record GameStake
{
    public int Stake { get; private set; }

    public static GameStake? Create(int stake)
    {
        if (stake < 0) return null;

        return new GameStake
        {
            Stake = stake
        };
    }
}