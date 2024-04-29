using SuperHeroApi.DTO;

namespace SuperHeroApi.Extentions
{
    public static class SuperHeroExtention
    {
        public static SuperHeroResponseDto MapSuperHeroToSuperHeroResponse(this SuperHero hero)
        {
            var heroResponse = new SuperHeroResponseDto();
            heroResponse.Name = hero.Name;
            heroResponse.FullName = $"{hero.FirstName} {hero.LastName}";
            heroResponse.Place = hero.Place;
            return heroResponse;
        }
        public static SuperHero MapSuperHeroCreateToSuperHero(this SuperHeroCreateDto heroCreate)
        {
            var hero = new SuperHero();
            hero.Name = heroCreate.Name;
            hero.FirstName = heroCreate.FirstName;
            hero.LastName = heroCreate.LastName;
            hero.Place = heroCreate.Place;

            return hero;
        }
    }
}
