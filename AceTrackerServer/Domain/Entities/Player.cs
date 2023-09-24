
namespace Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
