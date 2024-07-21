namespace E_Commerce_BL;

public interface ICategoryManager
{
    Task<IReadOnlyList<ReadCategoryDTO>> GetAll();
    Task<ReadCategoryDTO> GetById(int id);
    ReadCategoryDTO Add(AddCategoryDTO categoryDTO);
    bool Update(UpdateCategoryDTO categoryDTO);
    void Delete(int id);
}
