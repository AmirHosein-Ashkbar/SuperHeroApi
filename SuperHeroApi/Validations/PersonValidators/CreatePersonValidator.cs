using FluentValidation;
using SuperHeroApi.DTO.PersonDtos;
using SuperHeroApi.DTO.SuperHeroDtos;

namespace SuperHeroApi.Validations.PersonValidators;

public class CreatePersonValidator : AbstractValidator<PersonCreateDto>
{
    public CreatePersonValidator()
    {
        RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(30);
        RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(30);
        RuleFor(x => x.BirthPlace).NotNull().NotEmpty().MaximumLength(30);
    }
}
