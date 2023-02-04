using ZooAPI.Data.Contracts;

namespace ZooAPI.Data.Models;

public class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public string Created { get; set; }
    public string LastModified { get; set; }
}