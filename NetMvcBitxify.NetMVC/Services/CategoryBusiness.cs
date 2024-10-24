using NetMvcBitxify.DataLayer.Repositories.Interfaces;
using NetMvcBitxify.Entities;
using NetMvcBitxify.NetMVC.Services.Interfaces;

namespace NetMvcBitxify.NetMVC.Services;

public class CategoryBusiness:ICategoryBusiness
{
    
    private readonly ICategoryRepository _categoryRepository;

    public CategoryBusiness(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public Task<IEnumerable<Category>> GetAllAsync()
    {
        return _categoryRepository.GetAllAsync();
    }
}