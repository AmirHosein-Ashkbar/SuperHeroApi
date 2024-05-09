using FluentValidation;
using SuperHeroApi.Services.SuperHeroService;

namespace SuperHeroApi.Validations.CustomValidators;

public static class SuperHeroNameValidator
{
    public static IRuleBuilderOptions<T, string> UniqueName<T>
        (this IRuleBuilder<T, string> ruleBuilder, ISuperHeroService _superHeroService)
    {
        var SuperHeroes = _superHeroService.GetAllHeroes().Result;

        return 
            ruleBuilder.Must(name => !SuperHeroes.Any(s => s.Name == name))
                       .WithMessage("{PropertyName} Must be Unique , {PropertyValue} Already Exists in database.");
    }
}
