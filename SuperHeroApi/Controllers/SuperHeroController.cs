using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.DTO.SuperHeroDtos;
using AutoMapper;
using SuperHeroApi.Services.LeagueService;

namespace SuperHeroApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;
    private readonly IMapper _mapper;
    private readonly ILeagueService _leagueService;

    public SuperHeroController(ISuperHeroService superHeroService, IMapper mapper, ILeagueService leagueService)
    {
        _superHeroService = superHeroService;
        _mapper = mapper;
        _leagueService = leagueService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<SuperHeroResponseDto>>> GetAll(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();


        var result = await _superHeroService.GetAllHeroes();

        var heroes = new List<SuperHeroResponseDto>();
        foreach (var item in result)
        {
            var hero = _mapper.Map<SuperHeroResponseDto>(item);
            heroes.Add(hero);
        }
        return Ok(heroes);
    }

    [HttpGet("Get")]
    public async Task<ActionResult<SuperHeroResponseDto>> Get(int id, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();

        var isHeroExist = await _superHeroService.IsHeroExists(id);
        if (isHeroExist is false)
            return NotFound();


        var result = await _superHeroService.GetHero(id);

        var hero = _mapper.Map<SuperHeroResponseDto>(result);

        return Ok(hero);
    }

    [HttpPost("Add")]
    public async Task<ActionResult<SuperHeroResponseDto>> Add(SuperHeroCreateDto request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();


        var hero = _mapper.Map<SuperHero>(request);

        var result = await _superHeroService.AddHero(hero);

        var createdHero = _mapper.Map<SuperHeroResponseDto>(result);

        return Ok(createdHero);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<SuperHeroResponseDto>> Update(int id, SuperHeroCreateDto heroUpdate, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();

        var isHeroExist = await _superHeroService.IsHeroExists(id);
        if (isHeroExist is false)
            return NotFound();

        var hero = _mapper.Map<SuperHero>(heroUpdate);

        var result = await _superHeroService.UpdateHero(id, hero);

        var updatedHero = _mapper.Map<SuperHeroResponseDto>(result);

        return Ok(updatedHero);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<bool>> DeleteHero(int id, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();

        var isHeroExist = await _superHeroService.IsHeroExists(id);
        if (isHeroExist is false)
        {
            return NotFound(false);
        }
        var result = await _superHeroService.DeleteHero(id);

        return Ok(result);
    }

}
