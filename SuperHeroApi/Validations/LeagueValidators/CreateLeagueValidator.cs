using FluentValidation;
using SuperHeroApi.DTO.LeageDtos;

namespace SuperHeroApi.Validations.LeagueValidators;

public class CreateLeagueValidator : AbstractValidator<LeagueCreateDto> 
{
    public CreateLeagueValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(30);
    }
}
