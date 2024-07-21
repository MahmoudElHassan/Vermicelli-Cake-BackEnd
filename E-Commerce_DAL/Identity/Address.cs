namespace E_Commerce_DAL.Identity;

public class Address : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Flat { get; set; }
    public string Building { get; set; }
    public string Street { get; set; }
    public string Comment { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}