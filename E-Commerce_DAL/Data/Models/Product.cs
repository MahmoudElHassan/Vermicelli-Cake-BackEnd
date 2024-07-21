using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_DAL;

public class Product : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    //[Required]
    //[MaxLength(200)]
    //public string Description { get; set; } = string.Empty;
    [Range(18, 2)]
    public decimal Price { get; set; } = 0;

    [Required]
    public string PictureURL { get; set; } = string.Empty;

    //[ForeignKey("flavor")]
    //public int FlavorId { get; set; }
    //public Flavor flavor { get; set; }

    [ForeignKey("category")]
    public int CategoryId { get; set; }
    public Category category { get; set; }

}
