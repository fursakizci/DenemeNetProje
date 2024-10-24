using NetMvcBitxify.Entities;

namespace NetMvcBitxify.NetMVC.Services.Interfaces;

public interface IProductBusiness
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id); 
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<IEnumerable<Product>> GetAllWithCategoryAsync();
    Task<Product> GetByIdWithCategoryAsync(int id); 
}