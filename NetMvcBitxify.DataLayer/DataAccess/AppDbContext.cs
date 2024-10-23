using Microsoft.EntityFrameworkCore;
using NetMvcBitxify.Entities;

namespace NetMvcBitxify.DataLayer.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("tblProduct")
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();  
            
            base.OnModelCreating(modelBuilder);
        }
    }
}