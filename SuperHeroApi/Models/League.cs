using System.Text.Json.Serialization;

namespace SuperHeroApi.Models;

public class League
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<SuperHero>? SuperHeroes { get; set; } = new List<SuperHero>();
}
