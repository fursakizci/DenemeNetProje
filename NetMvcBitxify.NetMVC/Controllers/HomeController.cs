using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NetMvcBitxify.Entities;
using NetMvcBitxify.NetMVC.Models;
using NetMvcBitxify.NetMVC.Services.Interfaces;

namespace NetMvcBitxify.NetMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductBusiness _productBusiness;
    private readonly IMapper _mapper;

    public HomeController(
        ILogger<HomeController> logger,
        IProductBusiness productBusiness,
        IMapper mapper)
    {
        _logger = logger;
        _productBusiness = productBusiness;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            var product = _mapper.Map<Product>(productViewModel);
            await _productBusiness.AddAsync(product);
            
            return Json(new { success = true, message = "Added Successfuly." });
        }
        return Json(new{success=false,message="Invalid"});
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            var product = await _productBusiness.GetByIdAsync(productViewModel.Id);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found!" });
            }

            product.Name = productViewModel.Name;
            product.Price = productViewModel.Price;

            await _productBusiness.UpdateAsync(product);
            return Json(new { success = true, message = "Product updated successfully!" });
        }
        return Json(new { success = false, message = "Invalid product data!" });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _productBusiness.DeleteAsync(id);
        return Json(new { success = true, message = "Deleted successfuly" }); 
    }
    
    [Route("Home/Get/{id}")]
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _productBusiness.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var productViewModel = _mapper.Map<ProductViewModel>(product);
        return Json(productViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var allProduct = await _productBusiness.GetAllAsync();
        return Json(allProduct);
    }
    
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}