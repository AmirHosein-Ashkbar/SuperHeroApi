using SuperHeroApi.DTO;

namespace SuperHeroApi.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllHeroes();
    Task<SuperHero> GetHero(int id);
    Task<SuperHero> AddHero(SuperHero hero);
    Task<SuperHero> UpdateHero(SuperHero heroUpdate);
    Task<bool> DeleteHero(int id);

}
