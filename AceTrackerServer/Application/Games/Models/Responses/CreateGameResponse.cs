using Domain.Entities;
using Domain.Enums;

namespace Application.Games.Models.Responses
{
    public record CreateGameResponse
    {
        public int Id { get; set; }
        public int AmountOfChips { get; set; }
        public int Stake { get; set; }
        public DateTime Date { get; set; }
        public GameState State { get; set; }
    }
}
