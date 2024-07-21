using E_Commerce_BL;
using Microsoft.AspNetCore.Mvc;

namespace E;

public class CategoryController : BaseApiController
{
    #region Field
    private readonly ICategoryManager _categoryManager;
    #endregion

    #region Ctor
    public CategoryController(ICategoryManager categoryManager)
    {
        _categoryManager = categoryManager;
    }
    #endregion

    #region Method
    // GET: api/GetAllCategory
    [HttpGet("GetAllCategory")]
    public async Task<ActionResult<List<ReadCategoryDTO>>> GetAllBrand()
    {
        var result =  await _categoryManager.GetAll();
        return Ok(result);
    }

    // GET: api/GetCategoryById/5
    [HttpGet("GetCategoryById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadCategoryDTO>> GetBrandById(int id)
    {
        var dbBrand = await _categoryManager.GetById(id);

        if (dbBrand is null)
            return NotFound(new ApiResponse(404));

        return dbBrand;
    }


    // POST: api/AddCategory
    [HttpPost("AddCategory")]
    public ActionResult<ReadCategoryDTO> AddCategory(AddCategoryDTO categoryDTO)
    {
        var readcategoryDTO = _categoryManager.Add(categoryDTO);

        return CreatedAtAction("GetBrandById", new { id = readcategoryDTO.Id }, readcategoryDTO);
    }

    // PUT: api/EditCategory
    [HttpPut("EditCategory")]
    public ActionResult EditCategory(UpdateCategoryDTO categoryDTO)
    {
        //if (id != transaction.TransactionId)
        //{
        //    return BadRequest();
        //}

        var dbBrand = _categoryManager.Update(categoryDTO);

        if (dbBrand)
            return Ok(dbBrand);

        return NotFound();
    }

    // DELETE: api/DeleteCategory/5
    [HttpDelete("DeleteCategory/{id}")]
    public ActionResult DeleteCategory(int id)
    {
        _categoryManager.Delete(id);

        return NoContent();
    }

    #endregion
}
