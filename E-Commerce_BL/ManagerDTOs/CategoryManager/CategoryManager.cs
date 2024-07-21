using AutoMapper;
using E_Commerce_DAL;

namespace E_Commerce_BL;

public class CategoryManager : ICategoryManager
{
    #region Field
    private readonly ICategoryRepo _categoryRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CategoryManager(ICategoryRepo categoryRepo, IMapper maapper)
    {
        _categoryRepo = categoryRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public async Task<IReadOnlyList<ReadCategoryDTO>> GetAll()
    {
        var dbBrand = _categoryRepo.ListAllAsync().Result;

        return await Task.FromResult(_mapper.Map<List<ReadCategoryDTO>>(dbBrand));
    }

    public async Task<ReadCategoryDTO> GetById(int id)
    {
        var dbModel = _categoryRepo.GetByIdAsync(id).Result;

        return await Task.FromResult(_mapper.Map<ReadCategoryDTO>(dbModel));
    }

    public ReadCategoryDTO Add(AddCategoryDTO categoryDTO)
    {
        var dbModel = _mapper.Map<Category>(categoryDTO);

        //dbModel.Id = int.Parse;

        _categoryRepo.Add(dbModel);
        _categoryRepo.SaveChanges();

        return _mapper.Map<ReadCategoryDTO>(dbModel);
    }

    public bool Update(UpdateCategoryDTO categoryDTO)
    {
        var dbModel = _categoryRepo.GetByIdAsync(categoryDTO.Id);

        if (dbModel is null)
            return false;

        _mapper.Map(categoryDTO, dbModel);

        _categoryRepo.Update(dbModel.Result);
        _categoryRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _categoryRepo.DeleteById(id);
        _categoryRepo.SaveChanges();
    }
    #endregion
}
