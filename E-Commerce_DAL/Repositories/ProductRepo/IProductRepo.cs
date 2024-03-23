namespace E_Commerce_DAL;

public interface IProductRepo : IGenericRepo<Product>
{
    Task<IReadOnlyList<Product>> GetAllEagerLoad();
    Task<Product> GetByIdEagerLoad(int id);
}
