namespace E_Commerce_DAL;

public class ProductTypeRepo : GenericRepo<ProductType>, IProductTypeRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public ProductTypeRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
