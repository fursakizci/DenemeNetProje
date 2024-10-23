using NetMvcBitxify.Business.Interfaces;
using NetMvcBitxify.DataLayer.Repositories.Interfaces;

namespace NetMvcBitxify.Business;

public class GenericService<TEntity>:IGenericService<TEntity> where TEntity:class
{
    private readonly IGenericRepository<TEntity> _repository;

    public GenericService(IGenericRepository<TEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}