using System.Security.Claims;
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
    var username = User.Identity?.Name;
    var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value; // From ClaimTypes.NameIdentifier
    var audience = User.Claims.FirstOrDefault(c => c.Type == "aud")?.Value; // From audience claim
    var issuer = User.Claims.FirstOrDefault(c => c.Type == "iss")?.Value; // From audience claim
    var user = new UserDTO { Id = int.Parse(userId), Username = username ?? "Unknown" };
    return Ok(ApiResponseHelper.Success(user));
  }
}