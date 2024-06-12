using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

namespace SuperHeroApi.Models;

public class SuperHero
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Person Person { get; set; }
    public List<SuperPower> SuperPowers { get; set; } = new List<SuperPower>();
    public List<League>? Leagues { get; set; } = new List<League>();
}
