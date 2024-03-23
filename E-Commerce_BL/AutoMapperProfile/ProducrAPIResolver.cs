using AutoMapper;
using E_Commerce_DAL;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_BL;

public class ProducrAPIResolver : IValueResolver<Product, ReadProductDTO, string>
{
    private readonly IConfiguration _config;

    public ProducrAPIResolver(IConfiguration config)
    {
        _config = config;
    }
    public string Resolve(Product source, 
        ReadProductDTO destination, 
        string destMember, 
        ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureURL))
        {
            return _config["ApiUrl"] + source.PictureURL;
        }

        return null;
    }
}
