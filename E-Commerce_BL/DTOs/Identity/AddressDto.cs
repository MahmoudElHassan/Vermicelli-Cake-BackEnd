using System.ComponentModel.DataAnnotations;

namespace E_Commerce_BL;

public class AddressDto
{
    [Required]
   public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Flat { get; set; }
    [Required]
    public string Building { get; set; }
    [Required]
    public string Street { get; set; }

    //[Required]
    public string Comment { get; set; }
}