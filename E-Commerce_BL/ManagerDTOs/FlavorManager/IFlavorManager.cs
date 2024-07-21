namespace E_Commerce_BL;

public interface IFlavorManager
{
    Task<IReadOnlyList<ReadFlavorDTO>> GetAll();
    Task<ReadFlavorDTO> GetById(int id);
    ReadFlavorDTO Add(AddFlavorDTO flavorDTO);
    bool Update(UpdateFlavorDTO flavorDTO);
    void Delete(int id);
}
