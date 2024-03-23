using E_Commerce_BL;
using E_Commerce_DAL;
using Microsoft.AspNetCore.Mvc;

namespace E;

public class ProductsController : BaseApiController
{
    #region Field
    private readonly IProductManager _productManager;
    #endregion

    #region Ctor
    public ProductsController(IProductManager productManager)
    {
        _productManager = productManager;
    }
    #endregion

    #region Method
    // GET: api/GetAllProduct
    [HttpGet("GetAllProduct")]
    public async Task<ActionResult<IReadOnlyList<ReadProductDTO>>> GetAllProduct([FromQuery] ProductSpecParams productParams)
    { 
        var result = await _productManager.GetAll(productParams);

        return Ok(result);
    }

    // GET: api/GetProductById/5
    [HttpGet("GetProductById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ReadProductDTO>> GetProductById(int id)
    {
        var dbProduct = await _productManager.GetById(id);

        if (dbProduct is null || dbProduct.IsDelete is true)
            return NotFound(new ApiResponse(404));

        return dbProduct;
    }


    // POST: api/AddProduct
    [HttpPost("AddProduct")]
    public ActionResult<ReadProductDTO> AddProduct(AddProductDTO productDTO)
    {
        var readProductDTO = _productManager.Add(productDTO);

        return CreatedAtAction("GetProductById", new { id = readProductDTO.Id }, readProductDTO);
    }

    // PUT: api/EditProduct
    [HttpPut("EditProduct")]
    public ActionResult EditProduct(UpdateProductDTO productDTO)
    {
        //if (id != transaction.TransactionId)
        //{
        //    return BadRequest();
        //}

        var dbProduct = _productManager.Update(productDTO);

        if (dbProduct)
            return Ok(dbProduct);

        return NotFound();
    }

    // DELETE: api/DeleteProduct/5
    [HttpDelete("DeleteProduct/{id}")]
    public ActionResult DeleteProduct(int id)
    {
        _productManager.Delete(id);

        return NoContent();
    }

    #endregion
}
