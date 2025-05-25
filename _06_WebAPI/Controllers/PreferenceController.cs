using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PreferencesController : ControllerBase
{
  const string COOKIE_NAME = "UserPreferences";

  private readonly ILogger<PreferencesController> _logger;

  public PreferencesController(ILogger<PreferencesController> logger)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  [HttpGet("create-preferences")]
  public IActionResult GetPreferences()
  {
    try
    {
      UserPreference preference = new UserPreference
      {
        Id = Guid.NewGuid(),
        FontSize = "Medium",
        Language = "en-US",
        Theme = "System",
        NotificationsEnabled = true
      };
      // Set cookie options
      var cookieOptions = new CookieOptions
      {
        HttpOnly = true, // Prevent JavaScript access
        Secure = false,   // Set to true to only send over HTTPS (true is recommended)
        SameSite = SameSiteMode.Strict, // Mitigate CSRF
        Expires = DateTimeOffset.UtcNow.AddDays(30) // Persistent for 30 days
      };
      // Serialize preferences to JSON to store in a single cookie
      var preferenceJson = JsonSerializer.Serialize(preference);
      Response.Cookies.Append(COOKIE_NAME, preferenceJson, cookieOptions);
      return Ok("Cookie returned");
    }
    catch (Exception)
    {
      return StatusCode(500, "Error setting preferences");
    }
  }

  [HttpGet("access-preferences")]
  public IActionResult AccessPreferences()
  {
    try
    {
      if (Request.Cookies.ContainsKey(COOKIE_NAME))
      {
        var preference = JsonSerializer.Deserialize<UserPreference>(Request.Cookies[COOKIE_NAME]);
        _logger.LogInformation("Prefereces:{preference}", Request.Cookies[COOKIE_NAME]);
      }
      return Ok($"We accessed the cookie: {Request.Cookies[COOKIE_NAME]}");
    }
    catch (Exception)
    {
      return StatusCode(500, "Error setting preferences");
    }
  }

  [HttpDelete("clear-preferences")]
  public IActionResult ClearPreferences()
  {
    try
    {
      Response.Cookies.Delete(COOKIE_NAME);
      return Ok("Preferences cleared");
    }
    catch (Exception)
    {
      return StatusCode(500, "Error clearing preferences");
    }
  }
}