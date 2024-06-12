using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTO;
using SuperHeroApi.Models;
using System.Linq;

namespace SuperHeroApi.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetAllHeroes()
    {
        return await _context.SuperHeroes
            .Include(h => h.SuperPowers)
            .Include(h => h.Person)
            .Include(h => h.Leagues)
            .ToListAsync();
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var superHeroList = await GetAllHeroes();
        var superHero = superHeroList.Find(h => h.Id == id);
        
        if (superHero is null)
            return null;

        return superHero;
    }

    public async Task<SuperHero> AddHero(SuperHero heroCreate)
    {
        _context.SuperHeroes.Add(heroCreate);
        await _context.SaveChangesAsync();
        return heroCreate;

    }

    public async Task<SuperHero> UpdateHero(int id, SuperHero heroUpdate)
    {
        var superHeroList = await GetAllHeroes();
        var superHeroToUpdate = superHeroList.Find(h => h.Id == id);  
        

        superHeroToUpdate.Name = heroUpdate.Name;
        superHeroToUpdate.Person = heroUpdate.Person;
        

        // Emptying the powers list & Adding powers to powerslist 
        if (heroUpdate.SuperPowers is not null && heroUpdate.SuperPowers.Count is not 0 )
        {
            superHeroToUpdate.SuperPowers.Clear();
            foreach (var power in heroUpdate.SuperPowers)
            {
                superHeroToUpdate.SuperPowers.Add(power);
            }
        }
        // Emptying the league list & Adding powers to powerslist 
        if (heroUpdate.Leagues is not null && heroUpdate.Leagues.Count is not 0)
        {
            superHeroToUpdate.Leagues.Clear();
            foreach (var league in heroUpdate.Leagues)
            {
                superHeroToUpdate.Leagues.Add(league);
            }
        }

        await _context.SaveChangesAsync();

        return  superHeroToUpdate;

    }

    public async Task<bool> DeleteHero(int id)
    {
        var superHeroToDelete = await _context.SuperHeroes.FindAsync(id);

        _context.SuperHeroes.Remove(superHeroToDelete);

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> IsHeroExists(int id)
    {
        return await _context.SuperHeroes.AnyAsync(h => h.Id == id);
    }
}
