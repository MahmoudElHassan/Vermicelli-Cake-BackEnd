
namespace E_Commerce_DAL;

public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
{
    public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x =>
        (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
        (!productParams.CategoryId.HasValue || x.CategoryId == productParams.CategoryId))
    {

    }
}