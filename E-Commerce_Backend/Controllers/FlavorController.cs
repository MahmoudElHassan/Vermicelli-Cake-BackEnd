//using E_Commerce_BL;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;

//namespace E;

//public class FlavorController : BaseApiController
//{
//    #region Field
//    private readonly IFlavorManager _flavorManager;
//    #endregion

//    #region Ctor
//    public FlavorController(IFlavorManager flavorManager)
//    {
//        _flavorManager = flavorManager;
//    }
//    #endregion

//    #region Method
//    // GET: api/GetAllType
//    [HttpGet("GetAllType")]
//    public async Task<ActionResult<List<ReadFlavorDTO>>> GetAllType()
//    {
//        var result = await _flavorManager.GetAll();
//        return Ok(result);
//    }

//    // GET: api/GetTypeById/5
//    [HttpGet("GetTypeById/{id}")]
//    [ProducesResponseType(StatusCodes.Status200OK)]
//    [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
//    public async Task<ActionResult<ReadFlavorDTO>> GetTypeById(int id)
//    {
//        var dbType = await _flavorManager.GetById(id);

//        if (dbType is null)
//            return NotFound(new ApiResponse(404));

//        return dbType;
//    }


//    // POST: api/AddType
//    [HttpPost("AddType")]
//    public ActionResult<ReadFlavorDTO> AddProduct(AddFlavorDTO typeDTO)
//    {
//        var readTypeDTO = _flavorManager.Add(typeDTO);

//        return CreatedAtAction("GetTypeById", new { id = readTypeDTO.Id }, readTypeDTO);
//    }

//    // PUT: api/EditBrand
//    [HttpPut("EditType")]
//    public ActionResult EditType(UpdateFlavorDTO typeDTO)
//    {
//        //if (id != transaction.TransactionId)
//        //{
//        //    return BadRequest();
//        //}

//        var dbType = _flavorManager.Update(typeDTO);

//        if (dbType)
//            return Ok(dbType);

//        return NotFound();
//    }

//    // DELETE: api/DeleteType/5
//    [HttpDelete("DeleteType/{id}")]
//    public ActionResult DeleteType(int id)
//    {
//        _flavorManager.Delete(id);

//        return NoContent();
//    }

//    #endregion
//}
