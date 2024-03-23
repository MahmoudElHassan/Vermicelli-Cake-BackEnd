using Microsoft.EntityFrameworkCore;

namespace E_Commerce_DAL;

public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public GenericRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion


    #region Method

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        var result = await _context.Set<T>().FindAsync(id);

        if (result is null)
            return null;

        return result;
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }


    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entityToDelete = GetByIdAsync(id);

        if (entityToDelete is not null)
            _context.Set<T>().Remove(entityToDelete.Result);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }


    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
    #endregion
}
