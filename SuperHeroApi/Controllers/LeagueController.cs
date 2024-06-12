using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTO.LeageDtos;
using SuperHeroApi.Services.LeagueService;

namespace SuperHeroApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LeagueController : ControllerBase
{
    private readonly ILeagueService _leagueService;
    private readonly IMapper _mapper;

    public LeagueController(ILeagueService leagueService, IMapper mapper)
    {
        _leagueService = leagueService;
        _mapper = mapper;
    }


    [HttpGet("GetAll")]
    public async Task<ActionResult<List<LeagueResponseDto>>> GetAll()
    {
        var result = await _leagueService.GetAllLeagues();
        var leagues = new List<LeagueResponseDto>();
        foreach (var item in result) 
        {
           var league = _mapper.Map<LeagueResponseDto>(item);
           leagues.Add(league);
        }
        return Ok(leagues);
    }
    [HttpGet("Get")]
    public async Task<ActionResult<LeagueResponseDto>> Get(int id)
    {
        var isExist = await _leagueService.IsLeagueExists(id);
        if(!isExist) 
        { 
            return NotFound("Requested league doesn't exist");
        }
        var result = await _leagueService.GetLeague(id);
        var league = _mapper.Map<LeagueResponseDto>(result);
        return Ok(league);
    }
    [HttpPost("Add")]
    public async Task<ActionResult<LeagueResponseDto>> Add(LeagueCreateDto leagueCreate)
    {
        //var league = leagueCreate.MapLeagueCreateToLeague();
        var league = _mapper.Map<League>(leagueCreate);
        var result = await _leagueService.AddLeague(league);
        var createdLeague = _mapper.Map<LeagueResponseDto>(result);
        return Ok(createdLeague);
    }
    [HttpPut("Update")]
    public async Task<ActionResult<LeagueResponseDto>> Update(int id, LeagueCreateDto leagueUpdate)
    {
        var isExist = await _leagueService.IsLeagueExists(id);
        if (!isExist)
        {
            return NotFound("Requested league doesn't exist");
        }
        var league = _mapper.Map<League>(leagueUpdate);
        var result = await _leagueService.UpdateLeague(id, league);
        var updatedLeague = _mapper.Map<LeagueResponseDto>(result);
        return Ok(updatedLeague);
    }
    [HttpDelete("Delete")]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        var isExist = await _leagueService.IsLeagueExists(id);
        if (!isExist)
        {
            return NotFound("Requested league doesn't exist");
        }
        await _leagueService.DeleteLeague(id);
        return Ok(true);
    }


}
