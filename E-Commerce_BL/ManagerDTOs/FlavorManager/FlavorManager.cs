using AutoMapper;
using E_Commerce_DAL;

namespace E_Commerce_BL;

public class FlavorManager : IFlavorManager
{
    #region Field
    private readonly IFlavorRepo _flavorRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public FlavorManager(IFlavorRepo flavorRepo, IMapper maapper)
    {
        _flavorRepo = flavorRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public async Task<IReadOnlyList<ReadFlavorDTO>> GetAll()
    {
        var dbModel = _flavorRepo.ListAllAsync().Result;

        return await Task.FromResult(_mapper.Map<List<ReadFlavorDTO>>(dbModel));
    }

    public async Task<ReadFlavorDTO> GetById(int id)
    {
        var dbType = _flavorRepo.GetByIdAsync(id).Result;

        return await Task.FromResult(_mapper.Map<ReadFlavorDTO>(dbType));
    }

    public ReadFlavorDTO Add(AddFlavorDTO flavorDTO)
    {
        var dbModel = _mapper.Map<Flavor>(flavorDTO);

        //dbModel.Id = Guid.NewGuid();

        _flavorRepo.Add(dbModel);
        _flavorRepo.SaveChanges();

        return _mapper.Map<ReadFlavorDTO>(dbModel);
    }

    public bool Update(UpdateFlavorDTO flavorDTO)
    {
        var dbModel = _flavorRepo.GetByIdAsync(flavorDTO.Id);

        if (dbModel is null)
            return false;

        _mapper.Map(flavorDTO, dbModel);

        _flavorRepo.Update(dbModel.Result);
        _flavorRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _flavorRepo.DeleteById(id);
        _flavorRepo.SaveChanges();
    }
    #endregion
}
