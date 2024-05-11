using FluentValidation;
using SuperHeroApi.DTO.SuperHeroDtos;

namespace SuperHeroApi.Validations.SuperHeroValidations;

public class RequestSuperHeroValidator : AbstractValidator<SuperHeroRequestDto>
{
    public RequestSuperHeroValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
