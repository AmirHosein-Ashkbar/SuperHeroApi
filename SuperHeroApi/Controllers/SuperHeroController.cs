using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services.SuperHeroService;

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

        [HttpGet("getheroes")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var result = await _superHeroService.GetAllHeroes();
            return Ok(result);
        }

        [HttpGet("gethero/{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var result = await _superHeroService.GetHero(id);
            if (result == null)
                return NotFound("hero not found");
            return Ok(result);
        }

        [HttpPost("addhero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("updatehero/{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero hero)
        {
            var result = await _superHeroService.UpdateHero(id, hero);
            if (result == null)
                return NotFound("hero not found");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);
            if (result == null)
                return NotFound("hero not found");
            return Ok(result);
        }

    }
}
