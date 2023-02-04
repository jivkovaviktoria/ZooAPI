namespace ZooAPI.Data.Contracts;

public interface IEntity
{
    public Guid Id { get; set; }
    public string Created { get; set; }
    public string LastModified { get; set; }
}