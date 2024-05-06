using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.DTO;
using SuperHeroApi.Extentions;
using SuperHeroApi.Models;
using System.Linq;

namespace SuperHeroApi.Services.SuperHeroService;

public class SuperHeroService : ISuperHeroService
{
    //private static List<SuperHero> superHeroes = new List<SuperHero>
    //    {
    //        new SuperHero
    //        {
    //            Id=1,
    //            Name="Spider Man",
    //            FirstName="Peter",
    //            LastName="Parker",
    //            Place="New York City"
    //        },
    //        new SuperHero
    //        {
    //            Id=2,
    //            Name="BatMan",
    //            FirstName="Bruce",
    //            LastName="Wayne",
    //            Place="Gotham City"
    //        },
    //        new SuperHero
    //        {
    //            Id=3,
    //            Name="Iron Man",
    //            FirstName="Tony",
    //            LastName="Stark",
    //            Place="Long Island"
    //        },
    //    };
    private readonly DataContext _context;

    public SuperHeroService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<SuperHero>> GetAllHeroes()
    {
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero> GetHero(int id)
    {
        var superHero = await SearchHero(id);

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

    public async Task<SuperHero> UpdateHero(SuperHero heroUpdate)
    {
        var superHeroToUpdate = await _context.SuperHeroes.FindAsync(heroUpdate.Id);
        if (superHeroToUpdate is null)
            return null;

        superHeroToUpdate.Name = heroUpdate.Name;
        superHeroToUpdate.FirstName = heroUpdate.FirstName;
        superHeroToUpdate.LastName = heroUpdate.LastName;
        superHeroToUpdate.Place = heroUpdate.Place;

        await _context.SaveChangesAsync();

        return  superHeroToUpdate;

    }

    public async Task<bool> DeleteHero(int id)
    {
        var superHeroToDelete = await SearchHero(id);

        if(superHeroToDelete is null) 
            return false;

        _context.SuperHeroes.Remove(superHeroToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<SuperHero> SearchHero(int id)
    {
        var superHero = await _context.SuperHeroes.FindAsync(id);
        if (superHero is null)
            return null;

        return superHero;
    }
}
