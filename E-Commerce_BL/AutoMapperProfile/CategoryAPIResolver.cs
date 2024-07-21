using AutoMapper;
using E_Commerce_DAL;
using Microsoft.Extensions.Configuration;

namespace E_Commerce_BL;

public class CategoryAPIResolver : IValueResolver<Category, ReadCategoryDTO, string>
{
    private readonly IConfiguration _config;
    public CategoryAPIResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Category source,
     ReadCategoryDTO destination,
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
