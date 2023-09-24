using Domain.Entities;
using Domain.Enums;

namespace Application.Games.Models.Responses
{
    public record CreateGameResponse
    {
        public int Id { get; set; }
        public int AmountOfChips { get; set; }
        public int Contribution { get; set; }
        public IReadOnlyCollection<Player> Players { get; set; } = null!;
        public DateTime Date { get; set; }
        public GameState State { get; set; }
    }
}
