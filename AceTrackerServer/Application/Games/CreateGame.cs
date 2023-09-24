using Application.Common.BaseModels;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Commands;
using Application.Games.Models.Requests;
using Application.Games.Models.Responses;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Persistance.Data;

namespace Application.Games;

public record CreateGameCommand(CreateGameRequest Request) : IRequest<CreationResult<CreateGameResponse>>;

public class  Handler : IRequestHandler<CreateGameCommand, CreationResult<CreateGameResponse>>
{
    private readonly ICreationResult<CreateGameResponse> _result;
    private readonly AceTrackerDBContext _dbContext;
    public Handler(AceTrackerDBContext dbContext, ICreationResult<CreateGameResponse> creationResult, ICreationResult<CreateGameResponse> result)
    {
        _dbContext = dbContext;
        _result = result;
    }
    public async Task<CreationResult<CreateGameResponse>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var game = new Game()
        {
            AmountOfChips = command.Request.AmountOfChips,
            Contribution = command.Request.Contribution,
            Date = command.Request.Date,
            State = GameState.Created,
            Players = new List<Player>()
        };

        await _dbContext.AddAsync(game, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var response = new CreateGameResponse()
        {
            Id = game.Id,
            AmountOfChips = game.AmountOfChips,
            Contribution = game.Contribution,
            Date = game.Date,
            State = game.State,
            Players = new List<Player>() 
        };

        return response.Id != 0 ?  _result.IsSuccessful(response) : _result.IsUnsuccessful(response);

    }
} 
