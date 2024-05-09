using FluentValidation;
using SuperHeroApi.DTO;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;

namespace SuperHeroApi.Validations;

public class CreateSuperHeroValidator : AbstractValidator<SuperHeroCreateDto>
{
    public CreateSuperHeroValidator(ISuperHeroService superHeroService)
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("{PropertyName} Must not be null")
            .NotEmpty().WithMessage("Name Must not be Empty")
            .Length(3,25)
            .UniqueName(superHeroService);

        RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 25);
        RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 25);
        RuleFor(x => x.Place).NotNull().NotEmpty().Length(2, 25);
    }
    
}
