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
    try
    {
      return await _context
        .Categories.Select(
          c => new Category
          {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName,
            Description = c.Description
          })
        .ToListAsync();
    }
    catch (Exception ex)
    {
      // Becareful when returning exception messages
      return StatusCode(500, $"Database error: {ex.Message}");
    }
  }

  // GET: api/categories/{id} - Retrieve a single category by ID
  [HttpGet("{id}")]
  public async Task<ActionResult<Category>> GetCategory(int id)
  {
    var category = await _context.Categories
                                 .Where(c => c.CategoryId == id)
                                 .Select(c => new Category
                                 {
                                   CategoryId = c.CategoryId,
                                   CategoryName = c.CategoryName,
                                   Description = c.Description
                                 })
                                 .FirstOrDefaultAsync();
    if (category == null)
    {
      return NotFound($"Category with ID {id} not found.");
    }
    return category;
  }

  // POST: api/categories - Add a new category
  [HttpPost]
  public async Task<ActionResult<Category>> CreateCategory(Category category)
  {
    if (category == null)
    {
      return BadRequest("Invalid category data.");
    }

    //@todo: Show the risk of not catching exceptions
    // if (string.IsNullOrWhiteSpace(category.CategoryName))
    // {
    //   return BadRequest("Category Name is required");
    // }

    var newCategory = new Category
    {
      CategoryName = category.CategoryName,
      Description = category.Description
    };

    _context.Categories.Add(newCategory);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetCategory), new { id = newCategory.CategoryId }, newCategory);
  }

  // PUT: api/categories/{id} - Update an existing category
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateCategory(int id, Category category)
  {
    var existingCategory = await _context.Categories.FindAsync(id);
    if (existingCategory == null)
    {
      return NotFound($"Category with ID {id} not found.");
    }

    existingCategory.CategoryName = category.CategoryName;
    existingCategory.Description = category.Description;

    _context.Entry(existingCategory).State = EntityState.Modified;
    await _context.SaveChangesAsync();

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
