using NetMvcBitxify.Entities;

namespace NetMvcBitxify.DataLayer.Repositories.Interfaces;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();
    Task<Product> GetByIdWithCategoryAsync(int id); 
}