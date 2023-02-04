using ZooAPI.Data;
using ZooAPI.Data.Contracts;
using ZooAPI.Data.Models;

namespace AnimalAPI.Services;

public class ZooService : IService
{
    public ZooDbContext _zooDbContext;
    public IRepository<Zoo> Zoos { get; }

    public ZooService(ZooDbContext context)
    {
        this._zooDbContext = context;
        this.Zoos = new ZooRepository(context);
    }
    
    public void Save() => this._zooDbContext.SaveChanges();
}