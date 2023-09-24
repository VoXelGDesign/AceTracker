using Domain.Entities;
using Domain.Enums;

namespace Application.Games.Models.Requests
{
    public record CreateGameRequest(int AmountOfChips, int Contribution, IReadOnlyCollection<Player> Players,
        DateTime Date)
    {
        public CreateGameCommand ToCommand() =>
            new CreateGameCommand(this);
    };

}

