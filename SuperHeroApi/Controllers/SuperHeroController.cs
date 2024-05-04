using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTO;
using SuperHeroApi.Services.SuperHeroService;
using SuperHeroApi.Extentions;

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
    public async Task<ActionResult<BaseResponse<List<SuperHeroResponseDto>>>> GetAllHeroes()
    {
        var response = new BaseResponse<List<SuperHeroResponseDto>>();

        var result = await _superHeroService.GetAllHeroes();

        var heroes = new List<SuperHeroResponseDto>();
        foreach (var item in result)
        {
            var hero = new SuperHeroResponseDto();
            hero = item.MapSuperHeroToSuperHeroResponse();
            heroes.Add(hero);
        }
        response.Result = heroes;
        response.StatusCode = 200;
        response.Message = "OK";
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpPost("Get")]
    public async Task<ActionResult<BaseResponse<SuperHeroResponseDto>>> GetHero([FromBody] SuperHeroRequestDto requestedHero )
    {
        var response = new BaseResponse<SuperHeroResponseDto>();

        var result = await _superHeroService.GetHero(requestedHero);
        if (result is null)
        {
            response.Result = null;
            response.Message = "hero not found";
            response.StatusCode = 404;
            response.isSuccess = false;
            return NotFound(response);
        }
        var hero = new SuperHeroResponseDto();
        hero = result.MapSuperHeroToSuperHeroResponse();

        response.Result = hero;
        response.Message = "OK";
        response.StatusCode = 200;
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpPost("Add")]
    public async Task<ActionResult<BaseResponse<SuperHeroResponseDto>>> AddHero([FromBody]SuperHeroCreateDto heroCreate)
    {
        var response = new BaseResponse<SuperHeroResponseDto>();

        var result = await _superHeroService.AddHero(heroCreate);

        var createdHero = new SuperHeroResponseDto();
        createdHero = result.MapSuperHeroToSuperHeroResponse();

        response.Result = createdHero;
        response.Message = $"{createdHero.Name} is successfully added.";
        response.StatusCode = 200;
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpPut("Update")]
    public async Task<ActionResult<BaseResponse<SuperHeroResponseDto>>> UpdateHero([FromBody] SuperHeroUpdateDto heroUpdate)
    {
        var response = new BaseResponse<SuperHeroResponseDto>();

        var result = await _superHeroService.UpdateHero(heroUpdate);
        if (result is null)
        {
            response.Result = null;
            response.Message = "hero not found.";
            response.StatusCode = 404;
            response.isSuccess = false;
            return NotFound(response);
        }

        var updatedHero = new SuperHeroResponseDto();
        updatedHero = result.MapSuperHeroToSuperHeroResponse();

        response.Result = updatedHero;
        response.Message = $"{updatedHero.Name} is successfully updated.";
        response.StatusCode = 200;
        response.isSuccess = true;
        return Ok(response);
    }

    [HttpDelete]
    public async Task<BaseResponse<bool>> DeleteHero([FromBody]SuperHeroRequestDto requestedHero)
    {
        var response = new BaseResponse<bool>();

        var result = await _superHeroService.DeleteHero(requestedHero);
        if (result is false)
        {
            response.Result=false;
            response.Message = "SuperHero not found.";
            response.StatusCode = 404;
            response.isSuccess = false;
            return response;
        }
        response.Result = true;
        response.Message = "SuperHero deleted";
        response.StatusCode = 200;
        response.isSuccess = true;
        return response;
    }

}
