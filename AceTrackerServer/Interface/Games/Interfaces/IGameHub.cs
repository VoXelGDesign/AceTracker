using Application.Common.Interfaces;
using Domain.Entities;

namespace Interface.Games.Interfaces
{
    public interface IGameHub
    {
        public ICreationResult<Game> CreateGame();
        public int UpdateAmountOfChips(int amount);
        public int UpdateContribution(int amount);
        public void AddPlayer(int id);
        public int RemovePlayer(int id);
    }
}
