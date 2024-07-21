using E_Commerce_DAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_BL;

public class AddProductDTO
{
    public string Name { get; set; }
    //public string Description { get; set; }
    public decimal Price { get; set; } = 0;
    public string PictureURL { get; set; }
    //public string Flavor { get; set; }
    public string Category { get; set; }
}
