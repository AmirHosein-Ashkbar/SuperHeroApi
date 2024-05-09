using FluentValidation;
using SuperHeroApi.DTO;

namespace SuperHeroApi.Validations;

public class RequestSuperHeroValidator : AbstractValidator<SuperHeroRequestDto>
{
    public RequestSuperHeroValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
