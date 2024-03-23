using E_Commerce_DAL;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_BL;

public interface IProductManager
{
    Task<Pagination<ReadProductDTO>> GetAll([FromQuery] ProductSpecParams productParams);    
    Task<ReadProductDTO> GetById(int id);
    ReadProductDTO Add(AddProductDTO productDTO);
    bool Update(UpdateProductDTO productDTO);
    void Delete(int id);
}
