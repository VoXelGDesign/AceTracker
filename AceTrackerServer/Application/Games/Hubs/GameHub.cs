using AceTrackerServer.Data;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using SignalRSwaggerGen.Attributes;

namespace Application.Games.Hubs
{
    [SignalRHub]
    public sealed class GameHub: Hub
    {
        private AceTrackerDBContext _context;
        public GameHub(AceTrackerDBContext DbContext)
        {
            _context = DbContext;
        }
        
        public override async Task OnConnectedAsync()
        {
            //var user1 = new User()
            //{
            //    Name = "Kuba",
            //    Email = "test@test.com",
            //    Password = "haslo"
            //};

            //var user2 = new User()
            //{
            //    Name = "Dawid",
            //    Email = "test@test.com",
            //    Password = "haslo"
            //};

            //var player1 = new Player
            //{
            //    User = user1,
            //    Score = 3550
            //};

            //var player2 = new Player
            //{
            //    User = user2,
            //    Score = 6450
            //};

            //var game = new Game
            //{
            //    Date = DateTime.UtcNow,
            //    AmountOfChips = 5000,
            //    Contribution = 20
            //};

            

            //game.Players = new List<Player> { player1, player2 };

            //_context.Games.Add(game);
            //await _context.SaveChangesAsync();

            //await this.Clients.All.SendAsync("ReciveMessage", $"{Context.ConnectionId} has joined");
        }
    }
}
