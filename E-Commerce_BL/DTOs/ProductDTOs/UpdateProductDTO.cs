using E_Commerce_DAL;

namespace E_Commerce_BL;

public class UpdateProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    //public string Description { get; set; }
    public decimal Price { get; set; } = 0;
    public string PictureURL { get; set; }
    //public string Flavor { get; set; }
    public string Category { get; set; }
}
