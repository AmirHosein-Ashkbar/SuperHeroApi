using FluentValidation;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.Services.LeagueService;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;
using SuperHeroApi.Validations.PersonValidators;
using SuperHeroApi.Validations.SuperPowerValidators;
using System.Linq;

namespace SuperHeroApi.Validations.SuperHeroValidations;

public class CreateSuperHeroValidator : AbstractValidator<SuperHeroCreateDto>
{
    private readonly ILeagueService _leagueService;

    public CreateSuperHeroValidator(ISuperHeroService superHeroService, ILeagueService leagueService)
    {
        _leagueService = leagueService;
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} Must not be null")
            .NotEmpty().WithMessage("Name Must not be Empty")
            .MaximumLength(30);
            //.Must(name => !superHeroService.GetAllHeroes().Result.Where().Any(s => s.Name == name));
            //.UniqueName(superHeroService);

        //RuleFor(x => x)
        //    .Must((hero) => {
        //        return !superHeroService.GetAllHeroes().Result.Where(s => s.Name != hero.Name).Any(s => s.Name == hero.Name);
        //    });
      

        RuleForEach(x => x.SuperPowers).SetValidator(new CreateSuperPowerValidator());

        RuleForEach(x => x.LeagueIds)
            .Must(id => id is int ? true : false).WithMessage("{PropertyName} Must be number")
            .Must(id => leagueService.IsLeagueExists(id).Result)
            .WithMessage("{PropertyName} with id:{PropertyValue} does not exist.");

        RuleFor(x => x.Person).SetValidator(new CreatePersonValidator());
    }


   

}
