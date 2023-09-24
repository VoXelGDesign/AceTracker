using Domain.Enums;

namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int AmountOfChips { get; set; }
        public int Contribution { get; set; }
        public virtual ICollection<Player> Players { get; set; } = null!;
        public DateTime Date { get; set; }
        public GameState State { get; set; }
    }
}
