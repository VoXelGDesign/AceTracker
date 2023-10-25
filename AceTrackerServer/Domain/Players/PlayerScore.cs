namespace Domain.Players;

public record PlayerScore
{
    public int Score { get; private set; }

    internal PlayerScore(int score, int stake)
    {
        if (score < 0) Score = 0;
        if (score > stake) Score = 0;

        Score = score;
    }
}



