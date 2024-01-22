namespace SuperHeroApi.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id=1,
                    Name="Spider Man",
                    FirstName="Peter",
                    LastName="Parker",
                    Place="New York City"
                },
                new SuperHero
                {
                    Id=2,
                    Name="BatMan",
                    FirstName="Bruce",
                    LastName="Wayne",
                    Place="Gotham City"
                },
                new SuperHero
                {
                    Id=3,
                    Name="Iron Man",
                    FirstName="Tony",
                    LastName="Stark",
                    Place="Long Island"
                },
            };
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
            var superHero =await _context.SuperHeroes.FindAsync(id);

            if (superHero == null)
                return null;

            return superHero;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();

        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero hero)
        {
            var superHeroToUpdate = await _context.SuperHeroes.FindAsync(id);
            if (superHeroToUpdate == null)
                return null;

            superHeroToUpdate.Name = hero.Name;
            superHeroToUpdate.FirstName = hero.FirstName;
            superHeroToUpdate.LastName = hero.LastName;
            superHeroToUpdate.Place = hero.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();

        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var superHeroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (superHeroToDelete == null)
                return null;

            _context.SuperHeroes.Remove(superHeroToDelete);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();

        }
    }
}
