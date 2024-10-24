using NetMvcBitxify.Entities;

namespace NetMvcBitxify.NetMVC.Services.Interfaces;

public interface ICategoryBusiness
{
    Task<IEnumerable<Category>> GetAllAsync();
}