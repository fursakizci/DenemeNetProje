using Microsoft.EntityFrameworkCore;
using NetMvcBitxify.Business;
using NetMvcBitxify.Business.Interfaces;
using NetMvcBitxify.DataLayer.DataAccess;
using NetMvcBitxify.DataLayer.Repositories;
using NetMvcBitxify.DataLayer.Repositories.Interfaces;
using NetMvcBitxify.NetMVC.Services;
using NetMvcBitxify.NetMVC.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("NetMvcBitxify.DataLayer")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductBusiness, ProductBusiness>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();