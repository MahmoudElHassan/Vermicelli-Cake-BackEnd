namespace E_Commerce_DAL;

public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
{
    public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.CategoryId.HasValue || x.CategoryId == productParams.CategoryId)
            //(!productParams.FlavorId.HasValue || x.FlavorId == productParams.FlavorId)
            )
    {
        AddInclude(x => x.category);
        //AddInclude(x => x.flavor);
        //AddInclude(x=>x.IsDelete == false);
        AddOrderBy(x => x.Name);
        //ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1),
        //    productParams.PageSize);

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }
    }


    public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.category);
        //AddInclude(x => x.flavor);
        //AddInclude(x => x.IsDelete == false);
    }
}
