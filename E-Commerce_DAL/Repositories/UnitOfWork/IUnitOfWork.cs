namespace E_Commerce_DAL;

public interface IUnitOfWork : IDisposable
{
    IGenericRepo<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<int> Complete();
}