using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.DTO.SuperPowersDtos;
using SuperHeroApi.Extentions.SuperPowerMappingExtentions;

namespace SuperHeroApi.Extentions.SuperHeroMappingDtoExtentions;

public static class SuperHeroExtentions
{
    public static SuperHeroResponseDto MapSuperHeroToSuperHeroResponse(this SuperHero hero)
    {
        //mapping powers to powersResponse
        var powerResponseList = new List<SuperPowerResponseDto>();
        if(hero.SuperPowers is not null && hero.SuperPowers.Count is not 0) 
        {
            foreach (var power in hero.SuperPowers)
            {
                var powerResponse = power.MapSuperPowerToSuperPowerResponse();
                powerResponseList.Add(powerResponse);
            }
        }
        var heroResponse = new SuperHeroResponseDto(hero.Id, hero.Name, $"{hero.FirstName} {hero.LastName}", hero.Place, powerResponseList);
        return heroResponse;
    }
    public static SuperHero MapSuperHeroCreateToSuperHero(this SuperHeroCreateDto heroCreate)
    {
        var hero = new SuperHero();
        hero.Name = heroCreate.Name.Trim();
        hero.FirstName = heroCreate.FirstName.Trim();
        hero.LastName = heroCreate.LastName.Trim();
        hero.Place = heroCreate.Place.Trim();
        if (heroCreate.SuperPowers is not null && heroCreate.SuperPowers.Count is not 0)
        {
            foreach (var powerCreate in heroCreate.SuperPowers)
            {
                var power = powerCreate.MapSuperPowerCreateToSuperPower();
                hero.SuperPowers.Add(power);
            }
        } 
        
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
        if (heroUpdate.SuperPowers is not null && heroUpdate.SuperPowers.Count is not 0)
        {
            foreach (var powerCreate in heroUpdate.SuperPowers)
            {
                var power = powerCreate.MapSuperPowerCreateToSuperPower();
                hero.SuperPowers.Add(power);
            }
        }

        return hero;
    }

}
