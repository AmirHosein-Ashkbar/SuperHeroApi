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
    public async Task<ActionResult<BaseResponse<List<SuperHeroResponseDto>>>> GetAll(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();

        var response = new BaseResponse<List<SuperHeroResponseDto>>();

        var result = await _superHeroService.GetAllHeroes();

        var heroes = new List<SuperHeroResponseDto>();
        foreach (var item in result)
        {
            var hero = item.MapSuperHeroToSuperHeroResponse();
            heroes.Add(hero);
        }
        response.Result = heroes;
        response.StatusCode = 200;
        response.Message = "OK";
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpPost("Get")]
    public async Task<ActionResult<BaseResponse<SuperHeroResponseDto>>> Get(int id,CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();
        var response = new BaseResponse<SuperHeroResponseDto>();

        var isHeroExist = await _superHeroService.IsHeroExists(id);
        if (isHeroExist is false)
        {
            response.Result = null;
            response.Message = "hero not found";
            response.StatusCode = 404;
            response.isSuccess = false;
            return NotFound(response);
        }

        var result = await _superHeroService.GetHero(id);

        var hero = result.MapSuperHeroToSuperHeroResponse();

        response.Result = hero;
        response.Message = "OK";
        response.StatusCode = 200;
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpPost("Add")]
    public async Task<ActionResult<BaseResponse<SuperHeroResponseDto>>> Add(SuperHeroCreateDto request, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();

        var response = new BaseResponse<SuperHeroResponseDto>();
        
        var hero = request.MapSuperHeroCreateToSuperHero();

        var result = await _superHeroService.AddHero(hero);

        var createdHero = result.MapSuperHeroToSuperHeroResponse();

        response.Result = createdHero;
        response.Message = $"{createdHero.Name} is successfully added.";
        response.StatusCode = 200;
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<BaseResponse<SuperHeroResponseDto>>> Update(SuperHeroUpdateDto heroUpdate, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();

        var response = new BaseResponse<SuperHeroResponseDto>();
        var hero = heroUpdate.MapSuperHeroUpdateToSuperHero();
        
        var isHeroExist = await _superHeroService.IsHeroExists(heroUpdate.Id);
        if (isHeroExist is false)
        {
            response.Result = null;
            response.Message = "hero not found.";
            response.StatusCode = 404;
            response.isSuccess = false;
            return NotFound(response);
        }
        var result = await _superHeroService.UpdateHero(hero);

        var updatedHero = result.MapSuperHeroToSuperHeroResponse();

        response.Result = updatedHero;
        response.Message = $"{updatedHero.Name} is successfully updated.";
        response.StatusCode = 200;
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteHero(int id, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
            return BadRequest();
        
        var response = new BaseResponse<bool>();
        var isHeroExist = await _superHeroService.IsHeroExists(id);
        if (isHeroExist is false)
        {
            response.Result=false;
            response.Message = "SuperHero not found.";
            response.StatusCode = 404;
            response.isSuccess = false;
            return response;
        }
        var result = await _superHeroService.DeleteHero(id);
        response.Result = true;
        response.Message = "SuperHero deleted";
        response.StatusCode = 200;
        response.isSuccess = true;
        return response;
    }

}
