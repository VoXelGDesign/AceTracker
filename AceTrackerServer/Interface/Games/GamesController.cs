using Application.Common.BaseModels;
using Application.Common.Interfaces;
using Application.Games.Models.Requests;
using Application.Games.Models.Responses;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interface.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public Task<CreationResult<CreateGameResponse>> CreateGame([FromBody] CreateGameRequest createGameRequest)
            => _mediator.Send(createGameRequest.ToCommand());

        //[HttpGet]
        //public Task GetGames()
        //    => _mediator.Send(createGameRequest.ToCommand());

    }
}
