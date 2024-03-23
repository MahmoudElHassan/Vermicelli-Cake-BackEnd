using E_Commerce_BL;
using Microsoft.AspNetCore.Mvc;

namespace E;

public class ProductBrandController : BaseApiController
{
    #region Field
    private readonly IProductBrandManager _brandManager;
    #endregion

    #region Ctor
    public ProductBrandController(IProductBrandManager brandManager)
    {
        _brandManager = brandManager;
    }
    #endregion

    #region Method
    // GET: api/GetAllBrand
    [HttpGet("GetAllBrand")]
    public async Task<ActionResult<List<ReadProductBrandDTO>>> GetAllBrand()
    {
        var result =  await _brandManager.GetAll();
        return Ok(result);
    }

    // GET: api/GetBrandById/5
    [HttpGet("GetBrandById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadProductBrandDTO>> GetBrandById(int id)
    {
        var dbBrand = await _brandManager.GetById(id);

        if (dbBrand is null || dbBrand.IsDelete is true)
            return NotFound(new ApiResponse(404));

        return dbBrand;
    }


    // POST: api/AddBrand
    [HttpPost("AddBrand")]
    public ActionResult<ReadProductBrandDTO> AddProduct(AddProductBrandDTO brandDTO)
    {
        var readBrandDTO = _brandManager.Add(brandDTO);

        return CreatedAtAction("GetBrandById", new { id = readBrandDTO.Id }, readBrandDTO);
    }

    // PUT: api/EditBrand
    [HttpPut("EditBrand")]
    public ActionResult EditBrand(UpdateProductBrandDTO brandDTO)
    {
        //if (id != transaction.TransactionId)
        //{
        //    return BadRequest();
        //}

        var dbBrand = _brandManager.Update(brandDTO);

        if (dbBrand)
            return Ok(dbBrand);

        return NotFound();
    }

    // DELETE: api/DeleteBrand/5
    [HttpDelete("DeleteBrand/{id}")]
    public ActionResult DeleteBrand(int id)
    {
        _brandManager.Delete(id);

        return NoContent();
    }

    #endregion
}
