using FluentValidation;
using SuperHeroApi.DTO.SuperPowersDtos;

namespace SuperHeroApi.Validations.SuperPowerValidators;

public class CreateSuperPowerValidator : AbstractValidator<SuperPowerCreateDto>
{
    public CreateSuperPowerValidator()
    {
        RuleFor(p =>  p.Name).NotEmpty().NotNull().MaximumLength(30);   
        RuleFor(p => p.Description).MaximumLength(250);
    }
}
