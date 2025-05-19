using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;


namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesWithLogController : ControllerBase
{
  private readonly NorthWindContext _context;
  private readonly ILogger<CategoriesWithLogController> _logger;

  public CategoriesWithLogController(
    NorthWindContext context,
    ILogger<CategoriesWithLogController> logger)
  {
    _context = context;
    _logger = logger;
    _logger.LogInformation("Application loaded");
  }

  // GET: api/categories - Retrieve all categories
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
  {
    try
    {
      var categories = await _context.Categories.ToListAsync();
      _logger.LogInformation("Categories retrieved");
      return categories.Any() ? Ok(categories) : NoContent();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error on GetCategories");
      return Problem();
    }
  }

  // GET: api/categories/{id} - Retrieve a single category by ID
  public async Task<ActionResult<Category>> GetCategory(int id)
  {
    try
    {
      var category = await _context.Categories.FindAsync(id);
      if (category == null)
      {
        _logger.LogWarning("Category ID not found = {id}", id);
        return NotFound($"Category with ID {id} not found.");
      }
      return Ok(category);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error on GetCategory");
      return Problem();
    }
  }

  // POST: api/categories - Add a new category
  [HttpPost]
  public async Task<ActionResult<Category>> CreateCategory(Category category)
  {
    try
    {
      if (category == null)
      {
        return BadRequest("Invalid category data.");
      }
      if (string.IsNullOrWhiteSpace(category.CategoryName))
      {
        return BadRequest("Category Name is required");
      }
      var newCategory = new Category
      {
        CategoryName = category.CategoryName,
        Description = category.Description
      };
      _context.Categories.Add(newCategory);
      await _context.SaveChangesAsync();
      _logger.LogInformation("Category created: Name={name}; Description={description}",
        category.CategoryName,
        category.Description);
      return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CategoryId }, newCategory);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error on CreateCategory");
      return Problem();
    }
  }

  // PUT: api/categories/{id} - Update an existing category
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateCategory(int id, Category category)
  {
    try
    {
      var existingCategory = await _context.Categories.FindAsync(id);
      if (existingCategory == null)
      {
        return NotFound($"Category with ID {id} not found.");
      }
      existingCategory.CategoryName = category.CategoryName;
      existingCategory.Description = category.Description;
      await _context.SaveChangesAsync();
      _logger.LogInformation(
        "Category updated: Name=from:{prev_name} to:{name}; Description=from:{prev_description} to: {description}",
        existingCategory.CategoryName,
        category.CategoryName,
        existingCategory.Description,
        category.Description);
      return NoContent();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error on UpdateCategory");
      return Problem();
    }
  }

  // DELETE: api/categories/{id} - Remove a category
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCategory(int id)
  {
    try
    {
      var category = await _context.Categories.FindAsync(id);
      if (category == null)
      {
        return NotFound($"Category with ID {id} not found.");
      }
      _context.Categories.Remove(category);
      await _context.SaveChangesAsync();
      _logger.LogInformation("Category deleted:{id}", id);
      return NoContent();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error on DeleteCategory");
      return Problem();
    }
  }
}
