using E_Commerce_DAL.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_DAL;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    public Address Address { get; set; }
}