using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task1.Areas.Admin.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product Code is required.")]
    public string Code { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; set; }

    public string Description { get; set; }
}
