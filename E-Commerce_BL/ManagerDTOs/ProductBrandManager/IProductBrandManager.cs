namespace E_Commerce_BL;

public interface IProductBrandManager
{
    Task<IReadOnlyList<ReadProductBrandDTO>> GetAll();
    Task<ReadProductBrandDTO> GetById(int id);
    ReadProductBrandDTO Add(AddProductBrandDTO brandDTO);
    bool Update(UpdateProductBrandDTO brandDTO);
    void Delete(int id);
}
