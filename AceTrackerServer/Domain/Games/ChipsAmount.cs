namespace Domain.Games;

public record ChipsAmount
{
    public int Amount { get; private set; }

    public static ChipsAmount? Create(int amount)
    {
        if (amount < 0) return null;

        return new ChipsAmount
        {
            Amount = amount
        };
    }
}