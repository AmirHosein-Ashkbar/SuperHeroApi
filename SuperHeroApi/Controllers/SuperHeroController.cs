using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTO;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Extentions;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<SuperHeroResponseDto>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();

            var heroes = new List<SuperHeroResponseDto>();
            foreach (var item in result)
            {
                var hero = new SuperHeroResponseDto();
                hero = item.MapSuperHeroToSuperHeroResponse();
                heroes.Add(hero);
            }
            return Ok(heroes);
        }

        [HttpPost("get")]
        public async Task<ActionResult<SuperHeroResponseDto>> GetHero([FromBody] SuperHeroRequestDto requestedHero )
        {
            var result = await _superHeroService.GetHero(requestedHero);
            if (result == null)
                return NotFound("hero not found");

            var hero = new SuperHeroResponseDto();
            hero = result.MapSuperHeroToSuperHeroResponse();
            return Ok(hero);
        }

        [HttpPost("addhero")]
        public async Task<ActionResult<List<SuperHeroResponseDto>>> AddHero([FromBody]SuperHeroCreateDto heroCreate)
        {
            var result = await _superHeroService.AddHero(heroCreate);

            var createdHero = new SuperHeroResponseDto();
            createdHero = result.MapSuperHeroToSuperHeroResponse();
            return Ok(createdHero);
        }

        [HttpPut("updatehero")]
        public async Task<ActionResult<SuperHeroResponseDto>> UpdateHero([FromBody] SuperHeroUpdateDto heroUpdate)
        {
            var result = await _superHeroService.UpdateHero(heroUpdate);
            if (result == null)
                return NotFound("hero not found");

            var updatedHero = new SuperHeroResponseDto();
            updatedHero = result.MapSuperHeroToSuperHeroResponse();
            return Ok(updatedHero);
        }

        [HttpDelete]
        public async Task<bool> DeleteHero([FromBody]SuperHeroRequestDto requestedHero)
        {
            var result = await _superHeroService.DeleteHero(requestedHero);
            if (result == false)
                return false;
            return true;
        }

    }
}
