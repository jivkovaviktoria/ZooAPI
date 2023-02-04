namespace ZooAPI.Data.Contracts;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    TEntity GetAsync(Guid id);
    IEnumerable<TEntity> GetManyAsync();
    bool CreateAsync(TEntity entity);
    bool UpdateAsync(TEntity entity);
    bool DeleteAsync(Guid id);
}