using Microsoft.EntityFrameworkCore;
using NetMvcBitxify.DataLayer.DataAccess;
using NetMvcBitxify.DataLayer.Repositories.Interfaces;
using NetMvcBitxify.Entities;

namespace NetMvcBitxify.DataLayer.Repositories;

public class ProductRepository:GenericRepository<Product>,IProductRepository
{
    private readonly AppDbContext _context;
    private readonly DbSet<Product> _dbSet;
    
    public ProductRepository(AppDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<Product>();
    }
}