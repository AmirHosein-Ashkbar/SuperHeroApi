using FluentValidation;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;
using SuperHeroApi.Validations.PersonValidators;
using SuperHeroApi.Validations.SuperPowerValidators;

namespace SuperHeroApi.Validations.SuperHeroValidations;

public class CreateSuperHeroValidator : AbstractValidator<SuperHeroCreateDto>
{
    public CreateSuperHeroValidator(ISuperHeroService superHeroService)
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} Must not be null")
            .NotEmpty().WithMessage("Name Must not be Empty")
            .MaximumLength(30);
            //.UniqueName(superHeroService);

        RuleForEach(x => x.SuperPowers).SetValidator(new CreateSuperPowerValidator());

        RuleFor(x => x.Person).SetValidator(new CreatePersonValidator());
    }

}
