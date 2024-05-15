using FluentValidation;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;
using SuperHeroApi.Validations.PersonValidators;
using SuperHeroApi.Validations.SuperPowerValidators;

namespace SuperHeroApi.Validations.SuperHeroValidations;

public class UpdateSuperHeroValidator : AbstractValidator<SuperHeroUpdateDto>
{
    public UpdateSuperHeroValidator(ISuperHeroService supreHeroService)
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(30);
        RuleFor(x => x.Person).SetValidator(new CreatePersonValidator());
        RuleForEach(x => x.SuperPowers).SetValidator(new CreateSuperPowerValidator());
    }
}
