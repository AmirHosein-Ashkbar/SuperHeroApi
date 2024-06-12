global using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //SuperHeroes table
        var SuperHeroes = modelBuilder.Entity<SuperHero>();
        SuperHeroes.HasKey(h => h.Id);
        SuperHeroes.Property(h => h.Name).IsRequired().HasMaxLength(30);

        //SuperPowers table
        var SuperPowers = modelBuilder.Entity<SuperPower>();
        SuperPowers.HasKey(s => s.Id);
        SuperPowers.Property(p => p.Name).IsRequired().HasMaxLength(30);
        SuperPowers.Property(p => p.Description).HasMaxLength(250);
        //Person table
        var Person = modelBuilder.Entity<Person>();
        Person.HasKey(h => h.Id);
        Person.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
        Person.Property(p => p.LastName).IsRequired().HasMaxLength(30);
        Person.Property(p => p.BirthPlace).IsRequired().HasMaxLength(30);
        //Leagues Table
        var Leagues = modelBuilder.Entity<League>();
        Leagues.HasKey(h => h.Id);
        Leagues.Property(p => p.Name).IsRequired().HasMaxLength(30);

        #region Relations
        SuperPowers.HasOne(h => h.SuperHero).WithMany(p => p.SuperPowers);
        SuperHeroes.HasOne(h => h.Person).WithOne(p => p.SuperHero);
        SuperHeroes.HasMany(h => h.Leagues).WithMany(l => l.SuperHeroes);
        #endregion
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
    public DbSet<SuperPower> SuperPowers { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<League> Leagues { get; set; }
}
