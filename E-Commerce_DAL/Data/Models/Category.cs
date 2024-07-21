using System.ComponentModel.DataAnnotations;

namespace E_Commerce_DAL;

public class Category : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string PictureURL { get; set; } = string.Empty;
}