using Microsoft.EntityFrameworkCore;
using ZooAPI.Data.Contracts;
using ZooAPI.Data.Models;

namespace ZooAPI.Data;

public class ZooRepository : IRepository<Zoo>
{
    protected ZooDbContext _zooDbContext;

    public ZooRepository(ZooDbContext zooDbContext)
    {
        this._zooDbContext = zooDbContext ?? throw new ArgumentNullException(nameof(zooDbContext));
    }
    
    public Zoo GetAsync(Guid id) => this._zooDbContext.Zoos.Find(id);

    public IEnumerable<Zoo> GetManyAsync() => this._zooDbContext.Zoos.ToList();

    public bool CreateAsync(Zoo entity)
    {
        if (entity is null) return false;

        this._zooDbContext.Zoos.Add(entity);
        return true;
    }

    public bool UpdateAsync(Zoo entity)
    {
        if (entity is null || this._zooDbContext.Zoos.Contains(entity) == false) return false;

        var targetZoo = this._zooDbContext.Zoos.FirstOrDefault(z => z.Id == entity.Id);
        this._zooDbContext.Zoos.Remove(targetZoo);
        this._zooDbContext.Zoos.Add(entity);
        
        return true;
    }

    public bool DeleteAsync(Guid id)
    {
        var zoo = this._zooDbContext.Zoos.Find(id);
        
        if (zoo is null) return false;
        this._zooDbContext.Remove(zoo);
        return true;
    }
}