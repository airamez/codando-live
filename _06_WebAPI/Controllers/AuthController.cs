using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IConfiguration _configuration;

  public AuthController(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  [HttpPost("login")]
  public IActionResult Login([FromBody] LoginRequest request)
  {
    // Simulated user validation (replace with real database check)
    if (request.Username != "testuser" || request.Password != "password")
    {
      return Ok(ApiResponseHelper.Failure<UserDTO>("Invalid username or password"));
    }

    // Generate JWT
    var claims = new[]
    {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.NameIdentifier, "1")
        };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: creds);

    var jwt = new JwtSecurityTokenHandler().WriteToken(token);
    var user = new UserDTO { Id = 1, Username = request.Username };

    return Ok(ApiResponseHelper.Success(new { Token = jwt, User = user }));
  }
}