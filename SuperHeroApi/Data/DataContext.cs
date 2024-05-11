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
        SuperHeroes.Property(h => h.FirstName).IsRequired().HasMaxLength(30);
        SuperHeroes.Property(h => h.LastName).IsRequired().HasMaxLength(30);
        SuperHeroes.Property(h => h.Place).IsRequired().HasMaxLength(30);
        //SuperPowers table
        var SuperPowers = modelBuilder.Entity<SuperPower>();
        SuperPowers.HasKey(s => s.Id);
        SuperPowers.Property(p => p.Name).IsRequired().HasMaxLength(30);
        SuperPowers.Property(p => p.Description).HasMaxLength(250);

        #region Relations
        SuperPowers.HasOne(h => h.SuperHero).WithMany(p => p.SuperPowers);
        #endregion
    }

    public DbSet<SuperHero> SuperHeroes { get; set; }
    public DbSet<SuperPower> SuperPowers { get; set; }


}
