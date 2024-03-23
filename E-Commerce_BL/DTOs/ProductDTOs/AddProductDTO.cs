using E_Commerce_DAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_BL;

public class AddProductDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; } = 0;
    public string PictureURL { get; set; }
    public int ProductTypeId { get; set; }
    public int ProductBrandId { get; set; }
}
