using System.ComponentModel.DataAnnotations;

namespace NetMvcBitxify.NetMVC.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public double Price { get; set; }
}