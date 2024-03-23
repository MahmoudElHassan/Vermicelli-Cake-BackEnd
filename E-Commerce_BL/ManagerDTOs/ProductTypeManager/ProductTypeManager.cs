using AutoMapper;
using E_Commerce_DAL;

namespace E_Commerce_BL;

public class ProductTypeManager : IProductTypeManager
{
    #region Field
    private readonly IProductTypeRepo _typeRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public ProductTypeManager(IProductTypeRepo typeRepo, IMapper maapper)
    {
        _typeRepo = typeRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public async Task<IReadOnlyList<ReadProductTypeDTO>> GetAll()
    {
        var dbType = _typeRepo.ListAllAsync().Result.Where(d => d.IsDelete == false);

        return await Task.FromResult(_mapper.Map<List<ReadProductTypeDTO>>(dbType));
    }

    public async Task<ReadProductTypeDTO> GetById(int id)
    {
        var dbType = _typeRepo.GetByIdAsync(id).Result;

        return await Task.FromResult(_mapper.Map<ReadProductTypeDTO>(dbType));
    }

    public ReadProductTypeDTO Add(AddProductTypeDTO typeDTO)
    {
        var dbModel = _mapper.Map<ProductType>(typeDTO);

        //dbModel.Id = Guid.NewGuid();
        dbModel.IsDelete = false;

        _typeRepo.Add(dbModel);
        _typeRepo.SaveChanges();

        return _mapper.Map<ReadProductTypeDTO>(dbModel);
    }

    public bool Update(UpdateProductTypeDTO typeDTO)
    {
        var dbModel = _typeRepo.GetByIdAsync(typeDTO.Id);

        if (dbModel is null || dbModel.Result.IsDelete is true)
            return false;

        _mapper.Map(typeDTO, dbModel);

        _typeRepo.Update(dbModel.Result);
        _typeRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _typeRepo.DeleteById(id);
        _typeRepo.SaveChanges();
    }
    #endregion
}
