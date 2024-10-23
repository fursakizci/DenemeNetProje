using AutoMapper;
using NetMvcBitxify.Entities;

namespace NetMvcBitxify.NetMVC.Models.Mapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductViewModel>();
        CreateMap<ProductViewModel, Product>();
    }
}