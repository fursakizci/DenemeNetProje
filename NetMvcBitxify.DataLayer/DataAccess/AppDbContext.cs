using Microsoft.EntityFrameworkCore;
using NetMvcBitxify.Entities;

namespace NetMvcBitxify.DataLayer.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=localhost;Database=deneme;Integrated Security=true;TrustServerCertificate=True;");
        // }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("tblProduct")
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();  
            
            modelBuilder.Entity<Category>()
                .ToTable("tblCategory")
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();  
            
            base.OnModelCreating(modelBuilder);
        }
    }
}