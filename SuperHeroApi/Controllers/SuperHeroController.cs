using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTO;
using SuperHeroApi.Services.SuperHeroService;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SuperHeroApi.Extentions.SuperHeroMappingDtoExtentions;
using SuperHeroApi.DTO.SuperHeroDtos;
using SuperHeroApi.DTO.SuperPowersDtos;
using SuperHeroApi.Extentions.SuperPowerMappingExtentions;
using System.Threading;

namespace SuperHeroApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;

    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
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
            var hero = item.MapSuperHeroToSuperHeroResponse();
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

        var hero = result.MapSuperHeroToSuperHeroResponse();

        return Ok(hero);
    }

    [HttpPost("Add")]
    public async Task<ActionResult<SuperHeroResponseDto>> Add(SuperHeroCreateDto request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();


        var hero = request.MapSuperHeroCreateToSuperHero();

        var result = await _superHeroService.AddHero(hero);

        var createdHero = result.MapSuperHeroToSuperHeroResponse();

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

        var hero = heroUpdate.MapSuperHeroCreateToSuperHero();

        var result = await _superHeroService.UpdateHero(id, hero);

        var updatedHero = result.MapSuperHeroToSuperHeroResponse();

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
