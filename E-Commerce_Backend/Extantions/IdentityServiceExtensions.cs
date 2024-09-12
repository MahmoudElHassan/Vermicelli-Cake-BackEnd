using E_Commerce_BL;
using E_Commerce_DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace E;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration config)
    {
        var builder = services.AddIdentityCore<AppUser>();


        builder = new IdentityBuilder(builder.UserType, builder.Services);
        //builder.AddRoles<IdentityRole>();
        builder.AddEntityFrameworkStores<AppIdentityDbContext>();
        builder.AddSignInManager<SignInManager<AppUser>>();
        //builder.AddDefaultTokenProviders();


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 // options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                 //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                     ValidIssuer = config["Token:Issuer"],
                     ValidateIssuer = true,
                     ValidateAudience = false
                 };
             });

        return services;

    }
}