namespace E_Commerce_BL;

public interface IProductTypeManager
{
    Task<IReadOnlyList<ReadProductTypeDTO>> GetAll();
    Task<ReadProductTypeDTO> GetById(int id);
    ReadProductTypeDTO Add(AddProductTypeDTO typeDTO);
    bool Update(UpdateProductTypeDTO typeDTO);
    void Delete(int id);
}
