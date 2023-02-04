using ZooAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ZooAPI.Data;

public class AnimalsDbContext : DbContext
{
    public AnimalsDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<Zoo> Zoos { get; set; }
}