using FluentValidation;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;

namespace SuperHeroApi.Validations.SuperHeroValidations;

public class UpdateSuperHeroValidator : AbstractValidator<SuperHeroUpdateDto>
{
    public UpdateSuperHeroValidator(ISuperHeroService supreHeroService)
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(30);
        RuleFor(x => x.FirstName).NotEmpty().NotNull().MaximumLength(30);
        RuleFor(x => x.LastName).NotEmpty().NotNull().MaximumLength(30);
        RuleFor(x => x.Place).NotEmpty().NotNull().MaximumLength(30);
    }
}
