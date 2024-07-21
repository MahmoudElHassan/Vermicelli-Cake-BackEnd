namespace E_Commerce_DAL;

public class FlavorRepo : GenericRepo<Flavor>, IFlavorRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public FlavorRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
