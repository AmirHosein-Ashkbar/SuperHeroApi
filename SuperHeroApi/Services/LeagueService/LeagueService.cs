
namespace SuperHeroApi.Services.LeagueService;

public class LeagueService : ILeagueService
{
    private readonly DataContext _context;

    public LeagueService(DataContext context)
    {
        _context = context;
    }

    public async Task<League> AddLeague(League leagueCreate)
    {
        _context.Leagues.Add(leagueCreate);
        await _context.SaveChangesAsync();
        return leagueCreate;
    }

    public async Task<bool> DeleteLeague(int id)
    {
        var leagueToDelete = await _context.Leagues.FindAsync(id);

        _context.Leagues.Remove(leagueToDelete);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<League>> GetAllLeagues()
    {
        return await _context.Leagues.Include(l => l.SuperHeroes).ToListAsync();
    }

    public async Task<League> GetLeague(int id)
    {
        var leagues = await GetAllLeagues();
        var league = leagues.Find(l => l.Id == id);
        return league;
    }

    public async Task<List<League>> GetLeaguesByIds(List<int> idList)
    {
        var Leagues = new List<League>();
        foreach (var id in idList)
        {
            var league = await GetLeague(id);
            Leagues.Add(league);
        }
        return Leagues;
    }

    public async Task<bool> IsLeagueExists(int id)
    {
        var leagues = await GetAllLeagues();
        var isExist = leagues.Any(l => l.Id == id);
        return isExist;
    }

    public async Task<League> UpdateLeague(int id, League leagueUpdate)
    {
        var leagues = await GetAllLeagues();
        var leagueToUpdate = leagues.Find(l => l.Id == id);
       
        leagueToUpdate.Name = leagueUpdate.Name;
        
        await _context.SaveChangesAsync();
        
        return leagueToUpdate;
    }
}
