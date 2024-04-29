using SuperHeroApi.DTO;

namespace SuperHeroApi.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero> GetHero(SuperHeroRequestDto requestedHero);
        Task<SuperHero> AddHero(SuperHeroCreateDto hero);
        Task<SuperHero> UpdateHero(SuperHeroUpdateDto heroUpdate);
        Task<bool> DeleteHero(SuperHeroRequestDto requestedHero);

    }
}
