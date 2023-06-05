using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UsersAuth.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    [HttpGet("Test")]
    [Authorize(Policy = "Test")]
    public IActionResult Test()
    {
        return StatusCode(StatusCodes.Status200OK, new { Message = "Success" });
    }
}

