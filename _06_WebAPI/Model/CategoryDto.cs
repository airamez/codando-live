using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public class CategoryDto
{
  public int CategoryId { get; set; }

  [Required(ErrorMessage = "Category name is required")]
  [StringLength(15, ErrorMessage = "Category name cannot exceed 15 characters")]
  public string CategoryName { get; set; } = string.Empty;

  [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
  public string? Description { get; set; }
}