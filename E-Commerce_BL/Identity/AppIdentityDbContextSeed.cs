using E_Commerce_DAL;
using E_Commerce_DAL.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_BL;

public class AppIdentityDbContextSeed
{
    public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser
            {
                DisplayName = "Bob",
                Email = "bob@test.com",
                UserName = "bob@test.com",
                Address = new Address
                {
                    FirstName = "Bob",
                    LastName = "Bobbity",
                    Street = "10 The street",
                    City = "New York",
                    State = "NY",
                    Zipcode = "90210"
                }
            };

            await userManager.CreateAsync(user, "Pa$$w0rd");
        }
    }
}