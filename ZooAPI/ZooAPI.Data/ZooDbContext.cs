using Microsoft.EntityFrameworkCore;
using ZooAPI.Data.Models;

namespace ZooAPI.Data;

public class ZooDbContext : DbContext
{
    public ZooDbContext() { }
    public ZooDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Zoo> Zoos { get; set; }
    public DbSet<Animal> Animals { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>().HasKey(a => a.Id);
        modelBuilder.Entity<Animal>().Property(a => a.Type).IsRequired();
        modelBuilder.Entity<Animal>().Property(a => a.Name).IsRequired(false);

        modelBuilder.Entity<Zoo>().HasKey(z => z.Id);
        modelBuilder.Entity<Zoo>().Property(z => z.Name).IsRequired();
        modelBuilder.Entity<Zoo>().Property(z => z.Location).IsRequired();

        modelBuilder.Entity<Animal>().HasOne(a => a.Zoo)
            .WithMany(z => z.Animals)
            .HasForeignKey(a => a.ZooId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}