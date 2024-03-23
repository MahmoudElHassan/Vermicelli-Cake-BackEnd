
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_DAL;

public class ProductRepo : GenericRepo<Product>, IProductRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public ProductRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public async Task<IReadOnlyList<Product>> GetAllEagerLoad()
    {
        return await _context.Products
            .Include(p=>p.productBrand)
            .Include(p=>p.productType)
            .Where(d => d.IsDelete == false)
            .ToListAsync();
    }

    public async Task<Product> GetByIdEagerLoad(int id)
    {
        return await _context.Products
            .Include(p => p.productBrand)
            .Include(p => p.productType)
            .Where(d=>d.IsDelete == false)
            .FirstOrDefaultAsync(i => i.Id == id);
    }
    #endregion
}
