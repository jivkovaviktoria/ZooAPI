using ZooAPI.Data.Contracts;
using ZooAPI.Data.Models;

namespace AnimalAPI.Services;

public interface IService
{
    IRepository<Zoo> Zoos { get; }
    void Save();
}