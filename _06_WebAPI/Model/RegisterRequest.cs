using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class RegisterRequest
{
  [Required(ErrorMessage = "Login is required.")]
  [StringLength(20, ErrorMessage = "Login must be 20 characters or less.")]
  public string Login { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required.")]
  [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = "Confirm password is required.")]
  [Compare("Password", ErrorMessage = "Passwords do not match.")]
  public string ConfirmPassword { get; set; } = string.Empty;
}