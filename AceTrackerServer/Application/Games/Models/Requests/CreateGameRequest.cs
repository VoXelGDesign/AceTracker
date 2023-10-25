using Domain.Entities;
using Domain.Enums;

namespace Application.Games.Models.Requests
{
    public record CreateGameRequest(int AmountOfChips, int Stake)
    {
        public CreateGameCommand ToCommand() =>
            new CreateGameCommand(this);
    };

}

