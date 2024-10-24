using NetMvcBitxify.Business.Interfaces;
using NetMvcBitxify.DataLayer.Repositories.Interfaces;
using NetMvcBitxify.Entities;
using NetMvcBitxify.NetMVC.Services.Interfaces;

namespace NetMvcBitxify.NetMVC.Services;

public class ProductBusiness:IProductBusiness
{
    private readonly IProductRepository _productRepository;

    public ProductBusiness(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(Product product)
    {
        await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return await _productRepository.GetAllWithCategoryAsync();
    }

    public async Task<Product> GetByIdWithCategoryAsync(int id)
    {
        return await _productRepository.GetByIdWithCategoryAsync(id);
    }
}