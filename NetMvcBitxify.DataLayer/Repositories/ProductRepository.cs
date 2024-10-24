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

    public async Task<IEnumerable<Product>> GetAllWithCategoryAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .Select(p=> new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = new Category
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            })
            .ToListAsync();
    }

    public async Task<Product> GetByIdWithCategoryAsync(int id)
    {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
    }
}