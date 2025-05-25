using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  [Authorize]
  [HttpGet("profile")]
  public IActionResult GetProfile()
  {
    var username = User.Identity?.Name; // From JWT claims
    var user = new UserDTO { Id = 1, Username = username ?? "Unknown" };
    return Ok(ApiResponseHelper.Success(user));
  }
}