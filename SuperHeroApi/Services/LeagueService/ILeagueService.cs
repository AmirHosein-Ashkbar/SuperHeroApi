namespace SuperHeroApi.Services.LeagueService;

public interface ILeagueService
{
    Task<List<League>> GetAllLeagues();
    Task<League> GetLeague(int id);
    Task<List<League>> GetLeaguesByIds(List<int> idList);
    Task<League> AddLeague(League hero);
    Task<League> UpdateLeague(int id, League heroUpdate);
    Task<bool> DeleteLeague(int id);
    Task<bool> IsLeagueExists(int id);
}
