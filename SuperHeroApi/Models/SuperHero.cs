using System.ComponentModel.DataAnnotations;

namespace SuperHeroApi.Models;

public class SuperHero
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Person Person { get; set; }
    public List<SuperPower>? SuperPowers { get; set; } = new List<SuperPower>();
     
}
