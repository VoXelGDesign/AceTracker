using Application.Common.BaseModels;
using Application.Common.Interfaces;
using Application.Games;
using Application.Games.Models.Requests;
using Application.Games.Models.Responses;
using Domain.Entities;
using Domain.Enums;
using Interface.Games.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Persistance.Data;
using SignalRSwaggerGen.Attributes;

namespace Interface.Games.Hubs
{
    [SignalRHub]
    public sealed class GameHub: Hub
    {
        
        private readonly IMediator _mediator;
        public GameHub(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public  override async Task OnConnectedAsync()
        {
            await this.Clients.All.SendAsync("RecieveMessage",
                $"User {this.Context.UserIdentifier} connected.");
        }

        public Task<CreationResult<CreateGameResponse>> CreateGame()
        =>  _mediator.Send(new CreateGameRequest(5000, 20, new List<Player>(), DateTime.Now).ToCommand());
        
    }
}
