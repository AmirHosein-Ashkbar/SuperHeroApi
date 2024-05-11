using FluentValidation;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;

namespace SuperHeroApi.Validations.SuperHeroValidations;

public class CreateSuperHeroValidator : AbstractValidator<SuperHeroCreateDto>
{
    public CreateSuperHeroValidator(ISuperHeroService superHeroService)
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} Must not be null")
            .NotEmpty().WithMessage("Name Must not be Empty")
            .MaximumLength(30)
            .UniqueName(superHeroService);

        RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(30);
        RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(30);
        RuleFor(x => x.Place).NotNull().NotEmpty().MaximumLength(30);
    }

}
