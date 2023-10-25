using Application.Common.BaseModels;
using Application.Common.Interfaces;
using Application.Games.Models.Requests;
using Application.Games.Models.Responses;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Persistance.Data;

namespace Application.Games;

public record CreateGameCommand(CreateGameRequest Request) : IRequest<CreationResult<CreateGameResponse>>;

public class  Handler : IRequestHandler<CreateGameCommand, CreationResult<CreateGameResponse>>
{
    private readonly ICreationResult<CreateGameResponse> _result;
    private readonly AceTrackerDBContext _dbContext;
    private const int InncorecctId = 0;

    public Handler(AceTrackerDBContext dbContext, ICreationResult<CreateGameResponse> result)
    {
        _dbContext = dbContext;
        _result = result;
    }

    public async Task<CreationResult<CreateGameResponse>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var game = new Game()
        {
            AmountOfChips = command.Request.AmountOfChips,
            Stake = command.Request.Stake,
            Date = DateTime.Now,
            Players = new List<Player>()
        };
      
        await _dbContext.AddAsync(game, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        var response = new CreateGameResponse()
        {
            Id = game.Id,
            AmountOfChips = game.AmountOfChips,
            Stake = game.Stake,
            Date = game.Date,
            State = game.State
        };

        return response.Id == InncorecctId ? 
            _result.IsUnsuccessful(response) : _result.IsSuccessful(response);

    }

    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(x => x.Request.AmountOfChips)
                .GreaterThan(0)
                .WithMessage("The amount of chips must be greater than 0.");

            RuleFor(x => x.Request.Stake)
                .GreaterThan(0)
                .WithMessage("The stake must be greater than 0.");
        }
    }

} 


