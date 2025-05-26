using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IConfiguration _configuration;
  private readonly NorthWindContext _dbContext;
  private readonly ILogger<CategoriesProController> _logger;

  public AuthController(IConfiguration configuration, NorthWindContext context, ILogger<CategoriesProController> logger)
  {
    _configuration = configuration;
    _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequest request)
  {
    // Validate model using data annotations
    if (!ModelState.IsValid)
    {
      var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
      _logger.LogWarning("Invalid registration. Errors: {Errors}", string.Join(", ", errors));
      return Problem("Invalid input: " + string.Join(", ", errors));
    }

    // Check if login already exists
    if (await _dbContext.Users.AnyAsync(u => u.Login == request.Login))
    {
      _logger.LogWarning("Registration attempt with existing login: {Login}", request.Login);
      return Problem("Login already exists.");
    }

    /*
     * WARNING: Never log password or token
     */

    // Hash password
    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

    // Create new user
    var user = new User
    {
      Login = request.Login,
      Password = hashedPassword
    };

    // Save to database
    _dbContext.Users.Add(user);
    await _dbContext.SaveChangesAsync();

    _logger.LogInformation("Successful registration for login: {Login}", user.Login);
    return Ok();
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequest request)
  {
    // Validate model using data annotations
    if (!ModelState.IsValid)
    {
      var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
      _logger.LogWarning("Invalid login attempt due to model validation errors: {Errors}", string.Join(", ", errors));
      return Problem("Invalid input: " + string.Join(", ", errors));
    }

    // Query the database for the user
    var user = await _dbContext.Users
        .FirstOrDefaultAsync(u => u.Login == request.Username);

    // Check if user exists and verify password
    if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
    {
      _logger.LogWarning("Invalid login attempt for username: {Username}", request.Username);
      return Problem("Invalid username or password.");
    }

    // Generate JWT
    var claims = new[]
    {
      new Claim(ClaimTypes.Name, user.Login),
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

    string? keyString = _configuration["Jwt:Key"];
    if (string.IsNullOrEmpty(keyString))
    {
      _logger.LogError("JWT Key configuration is missing or empty.");
      return Problem("Server configuration error: JWT Key is missing.");
    }

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        issuer: _configuration["Jwt:Issuer"],
        audience: _configuration["Jwt:Audience"],
        claims: claims,
        expires: DateTime.Now.AddMinutes(5),
        signingCredentials: creds);

    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

    _logger.LogInformation("Successful login for username: {Username}", user.Login);
    Response.Headers["jwt-token"] = jwt;
    return Ok();
  }
}