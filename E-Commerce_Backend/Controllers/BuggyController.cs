using E_Commerce_DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E;

public class BuggyController : BaseApiController
{
    private readonly ApplicationDbContext _context;

    public BuggyController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpGet("testauth")]
    [Authorize]
    public ActionResult<string> GetSecretText()
    {
        return "secret stuff";
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFoundRequst()
    {
        var thing = _context.Products.Find(100);

        if (thing is null)
            return NotFound(new ApiResponse(404));

        return Ok();
    }

    [HttpGet("servererror")]
    public ActionResult GetServerErrorRequst()
    {
        var thing = _context.Products.Find(100);

        var returnThing = thing.ToString();

        return Ok();
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequestRequst()
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetBadRequestRequst(int id)
    {
        return Ok();
    }
}
