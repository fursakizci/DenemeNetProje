namespace NetMvcBitxify.DataLayer.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity:class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
}