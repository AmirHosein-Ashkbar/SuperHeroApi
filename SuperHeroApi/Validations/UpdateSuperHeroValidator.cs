using FluentValidation;
using SuperHeroApi.DTO;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Validations.CustomValidators;

namespace SuperHeroApi.Validations;

public class UpdateSuperHeroValidator : AbstractValidator<SuperHeroUpdateDto>
{
    public UpdateSuperHeroValidator(ISuperHeroService supreHeroService)
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull().Length(3,25).UniqueName(supreHeroService);
        RuleFor(x => x.FirstName).NotEmpty().NotNull().Length(3, 25);
        RuleFor(x => x.LastName).NotEmpty().NotNull().Length(3, 25);
        RuleFor(x => x.Place).NotEmpty().NotNull().Length(2, 25);
    }
}
