using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
  private readonly NorthWindContext _context;

  public CategoriesController(NorthWindContext context)
  {
    _context = context;
  }

  // GET: api/categories - Retrieve all categories
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
  {
    var categories = await _context.Categories.ToListAsync();
    return categories.Any() ? Ok(categories) : NoContent();
  }

  // GET: api/categories/{id} - Retrieve a single category by ID
  [HttpGet("{id}")]
  public async Task<ActionResult<Category>> GetCategory(int id)
  {
    var category = await _context.Categories.FindAsync(id);
    if (category == null)
    {
      return NotFound($"Category with ID {id} not found.");
    }
    return Ok(category);
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
      //@todo: Show the risk of not catching exceptions
      if (string.IsNullOrWhiteSpace(category.CategoryName))
      {
        return BadRequest("Category Name is required");
      }
      if (category.CategoryName.Length > 15)
      {
        return BadRequest("Category Name Length max is 15");
      }
      // if (category.CategoryName.Length > 15)
      // {
      //   category.CategoryName = category.CategoryName.Substring(0, 15);
      // }
      _context.Categories.Add(category);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
    }
    catch (Exception)
    {
      return StatusCode(500, "Unexpected Error! Try again later!");
    }
  }

  // PUT: api/categories/{id} - Update an existing category
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateCategory(int id, Category category)
  {
    //@todo: cause exceptions to show the how to deal with it
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
    }
    catch (Exception ex)
    {
      // Becareful when returning exception messages
      return StatusCode(500, $"Database error: {ex.Message}");
    }
    return NoContent();
  }

  // DELETE: api/categories/{id} - Remove a category
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteCategory(int id)
  {
    var category = await _context.Categories.FindAsync(id);
    if (category == null)
    {
      return NotFound($"Category with ID {id} not found.");
    }
    _context.Categories.Remove(category);
    await _context.SaveChangesAsync();
    return NoContent();
  }
}
