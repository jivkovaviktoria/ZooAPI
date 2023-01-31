using AnimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Data;

public class AnimalsDbContext : DbContext
{
    public AnimalsDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Animal> Animals { get; set; }
}