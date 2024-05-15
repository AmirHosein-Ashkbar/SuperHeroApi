using Microsoft.EntityFrameworkCore;
using SuperHeroApi.DTO;

namespace SuperHeroApi.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllHeroes();
    Task<SuperHero> GetHero(int id);
    Task<SuperHero> AddHero(SuperHero hero);
    Task<SuperHero> UpdateHero(int id, SuperHero heroUpdate);
    Task<bool> DeleteHero(int id);
    Task<bool> IsHeroExists(int id);
    

}
