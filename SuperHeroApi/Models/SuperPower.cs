using System.Text.Json.Serialization;

namespace SuperHeroApi.Models;

public class SuperPower
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public SuperHero SuperHero { get; set; }
}
