namespace E_Commerce_DAL;

public class ProductBrandRepo : GenericRepo<ProductBrand>, IProductBrandRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public ProductBrandRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
