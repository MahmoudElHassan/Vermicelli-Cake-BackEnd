using AutoMapper;
using E_Commerce_DAL;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_BL;

public class ProductManager : IProductManager
{
    #region Field
    private readonly IProductRepo _productRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public ProductManager(IProductRepo productRepo, IMapper maapper)
    {
        _productRepo = productRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public async Task<Pagination<ReadProductDTO>> GetAll([FromQuery] ProductSpecParams productParams)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
        var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

        var totalItems = await _productRepo.CountAsync(countSpec);
        var products = await _productRepo.ListAsync(spec);

        var data = _mapper.Map<IReadOnlyList<ReadProductDTO>>(products);

        var result = new Pagination<ReadProductDTO>(productParams.PageIndex,
            productParams.PageSize, totalItems, data);

        return result;

    }

    public async Task<ReadProductDTO> GetById(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);

        var dbProduct = await _productRepo.GetEntityWithSpec(spec);

        return _mapper.Map<ReadProductDTO>(dbProduct);
    }

    public ReadProductDTO Add(AddProductDTO productDTO)
    {
        var dbModel = _mapper.Map<Product>(productDTO);

        //dbModel.Id = Guid.NewGuid();
        dbModel.IsDelete = false;

        _productRepo.Add(dbModel);
        _productRepo.SaveChanges();

        return _mapper.Map<ReadProductDTO>(dbModel);
    }

    public bool Update(UpdateProductDTO productDTO)
    {
        var dbModel = _productRepo.GetByIdAsync(productDTO.Id);

        if (dbModel is null || dbModel.Result.IsDelete is true)
            return false;

        _mapper.Map(productDTO, dbModel);

        _productRepo.Update(dbModel.Result);
        _productRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _productRepo.DeleteById(id);
        _productRepo.SaveChanges();
    }

    #endregion
}
