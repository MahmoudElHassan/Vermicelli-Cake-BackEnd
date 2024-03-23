using E_Commerce_BL;
using E_Commerce_DAL;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace E;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region Reposatories
        services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
        services.AddScoped<IProductRepo, ProductRepo>();
        services.AddScoped<IProductBrandRepo, ProductBrandRepo>();
        services.AddScoped<IProductTypeRepo, ProductTypeRepo>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        #endregion

        #region Managers
        services.AddScoped<IProductManager, ProductManager>();
        services.AddScoped<IProductBrandManager, ProductBrandManager>();
        services.AddScoped<IProductTypeManager, ProductTypeManager>();
        services.AddScoped<IBasketManager, BasketManager>();
        services.AddScoped<IOrderManager, OrderManager>();
        #endregion

        services.Configure<ApiBehaviorOptions>(options =>
         {
             options.InvalidModelStateResponseFactory = actionContext =>
             {
                 var errors = actionContext.ModelState
                 .Where(x => x.Value.Errors.Count > 0)
                 .SelectMany(x => x.Value.Errors)
                 .Select(x => x.ErrorMessage).ToArray();
                 var errorResponse = new ApiValidationErrorResponse
                 {
                     Errors = errors
                 };
                 return new BadRequestObjectResult(errorResponse);
             };
         });

        #region Allow Cors
        services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });
        #endregion



        return services;
    }
}
