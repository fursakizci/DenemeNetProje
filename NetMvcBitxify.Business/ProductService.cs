using NetMvcBitxify.Business.Interfaces;
using NetMvcBitxify.DataLayer.Repositories.Interfaces;
using NetMvcBitxify.Entities;

namespace NetMvcBitxify.Business;

public class ProductService: GenericService<Product>,IProductService
{
    public ProductService(IGenericRepository<Product> repository) : base(repository)
    {
    }
}