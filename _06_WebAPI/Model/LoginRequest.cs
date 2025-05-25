using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class LoginRequest
{
  [Required(ErrorMessage = "Username is required.")]
  [StringLength(20, ErrorMessage = "Username must be 20 characters or less.")]
  public string Username { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required.")]
  [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
  public string Password { get; set; } = string.Empty;
}