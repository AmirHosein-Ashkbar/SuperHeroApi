using SuperHeroApi.DTO;

namespace SuperHeroApi.Extentions;

public static class SuperHeroExtention
{
    public static SuperHeroResponseDto MapSuperHeroToSuperHeroResponse(this SuperHero hero)
    {
        var heroResponse = new SuperHeroResponseDto(hero.Id , hero.Name, $"{hero.FirstName} {hero.LastName}", hero.Place);
        return heroResponse;
    }
    public static SuperHero MapSuperHeroCreateToSuperHero(this SuperHeroCreateDto heroCreate)
    {
        var hero = new SuperHero();
        hero.Name = heroCreate.Name.Trim();
        hero.FirstName = heroCreate.FirstName.Trim();
        hero.LastName = heroCreate.LastName.Trim();
        hero.Place = heroCreate.Place.Trim();

        return hero;
    }
    public static SuperHero MapSuperHeroUpdateToSuperHero(this SuperHeroUpdateDto heroUpdate)
    {
        var hero = new SuperHero();
        hero.Id = heroUpdate.Id;
        hero.Name = heroUpdate.Name.Trim();
        hero.FirstName = heroUpdate.FirstName.Trim();
        hero.LastName = heroUpdate.LastName.Trim();
        hero.Place = heroUpdate.Place.Trim();

        return hero;
    }
    
}
