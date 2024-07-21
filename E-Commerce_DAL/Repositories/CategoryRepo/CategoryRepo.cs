namespace E_Commerce_DAL;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public CategoryRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
