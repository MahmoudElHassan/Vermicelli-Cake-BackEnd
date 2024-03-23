using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;

namespace E_Commerce_DAL;

public class StoreContextSeed
{

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        //if (!context.ProductBrands.Any())
        //{
        //    var brandsData = File.ReadAllText(path + @"/Data/SeedData/brands.json");
        //    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
        //    context.ProductBrands.AddRange(brands);
        //}

        //if (!context.ProductTypes.Any())
        //{
        //    var typesData = File.ReadAllText(path + @"/Data/SeedData/types.json");
        //    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
        //    context.ProductTypes.AddRange(types);
        //}

        //if (!context.Products.Any())
        //{
        //    var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");
        //    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
        //    context.Products.AddRange(products);
        //}

        if (!context.DeliveryMethods.Any())
        {
            var deliveryData = File.ReadAllText(path + @"/Data/SeedData/delivery.json");
            var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
            context.DeliveryMethods.AddRange(methods);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }

    //public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
    //{
    //    try
    //    {
    //        //if (!context.ProductBrands.Any())
    //        //{
    //        //    var brandsData = File.ReadAllText("../E_Commerce_DAL/Data/SeedData/brands.json");
    //        //    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
    //        //    foreach (var item in brands)
    //        //    {
    //        //        context.ProductBrands.Add(item);
    //        //    }
    //        //    await context.SaveChangesAsync();
    //        //}

    //        //if (!context.ProductTypes.Any())
    //        //{
    //        //    var typeData = File.ReadAllText("../E_Commerce_DAL/Data/SeedData/types.json");
    //        //    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
    //        //    //D:\Projects\E-Commerce\E-Commerce_Backend\E-Commerce_DAL\Data\SeedData\brands.json
    //        //    foreach (var item in types)
    //        //    {
    //        //        context.ProductTypes.Add(item);
    //        //    }
    //        //    await context.SaveChangesAsync();
    //        //}

    //        //if (!context.Products.Any())
    //        //{
    //        //    var productsData = File.ReadAllText("../E_Commerce_DAL/Data/SeedData/products.json");
    //        //    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
    //        //    foreach (var item in products)
    //        //    {
    //        //        context.Products.Add(item);
    //        //    }
    //        //    await context.SaveChangesAsync();
    //        //}

    //        if (!context.DeliveryMethods.Any())
    //        {
    //            var deliveryData = File.ReadAllText("D:\\_Projects\\E-Commerce\\E-Commerce_Backend\\E-Commerce_DAL\\Data\\SeedData\\delivery.json");
    //            var delivery = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
    //            foreach (var item in delivery)
    //            {
    //                context.DeliveryMethods.Add(item);
    //            }
    //            await context.SaveChangesAsync();
    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //        var logger = loggerFactory.CreateLogger<StoreContextSeed>();
    //        logger.LogError(ex.Message);
    //    }


    //    //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    //    //if (!context.ProductBrands.Any())
    //    //{
    //    //    var brandsData = File.ReadAllText(path + @"/Data/SeedData/brands.json");
    //    //    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
    //    //    context.ProductBrands.AddRange(brands);
    //    //}

    //    //if (!context.ProductTypes.Any())
    //    //{
    //    //    var typesData = File.ReadAllText(path + @"/Data/SeedData/types.json");
    //    //    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
    //    //    context.ProductTypes.AddRange(types);
    //    //}

    //    //if (!context.Products.Any())
    //    //{
    //    //    var productsData = File.ReadAllText(path + @"/Data/SeedData/products.json");
    //    //    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
    //    //    context.Products.AddRange(products);
    //    //}

    //    ////if (!context.DeliveryMethods.Any())
    //    ////{
    //    ////    var deliveryData = File.ReadAllText(path + @"/Data/SeedData/delivery.json");
    //    ////    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
    //    ////    context.DeliveryMethods.AddRange(methods);
    //    ////}

    //    //if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    //}
}