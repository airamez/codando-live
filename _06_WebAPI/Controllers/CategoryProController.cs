using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using WebAPI.Models;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesProController : ControllerBase
{
  private readonly NorthWindContext _context;
  private readonly ILogger<CategoriesProController> _logger;

  public CategoriesProController(
      NorthWindContext context,
      ILogger<CategoriesProController> logger)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _logger.LogInformation("CategoriesProController initialized");
  }

  // GET: api/CategoriesPro - Retrieve all categories
  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ApiResponse<IEnumerable<CategoryDto>>>> GetCategories()
  {
    /*
     * NOTE: Remember to explain about the async Task
     */
    try
    {
      _logger.LogInformation("Fetching all categories");
      var categories = await _context.Categories
          .Select(c => new CategoryDto
          {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName,
            Description = c.Description
          })
          .ToListAsync();

      return Ok(new ApiResponse<IEnumerable<CategoryDto>>
      {
        Success = true,
        Data = categories.Any() ? categories : null,
        ErrorMessage = categories.Any() ? null : "No categories found"
      });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Failed to retrieve categories");
      return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<IEnumerable<CategoryDto>>
      {
        Success = false,
        ErrorMessage = "An error occurred while retrieving categories"
      });
    }
  }

  // GET: api/CategoriesPro/{id} - Retrieve a single category by ID
  [HttpGet("{id}")]
  [ProducesResponseType(StatusCodes.Status200OK)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ApiResponse<CategoryDto>>> GetCategory(int id)
  {
    try
    {
      _logger.LogInformation("Fetching category with ID {CategoryId}", id);
      var category = await _context.Categories
          .Where(c => c.CategoryId == id)
          .Select(c => new CategoryDto
          {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName,
            Description = c.Description
          })
          .FirstOrDefaultAsync();

      if (category == null)
      {
        _logger.LogWarning("Category with ID {CategoryId} not found", id);
        return NotFound(new ApiResponse<CategoryDto>
        {
          Success = false,
          ErrorMessage = $"Category with ID {id} not found"
        });
      }

      return Ok(new ApiResponse<CategoryDto>
      {
        Success = true,
        Data = category
      });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Failed to retrieve category with ID {CategoryId}", id);
      return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<CategoryDto>
      {
        Success = false,
        ErrorMessage = "An error occurred while retrieving the category"
      });
    }
  }

  // POST: api/CategoriesPro - Add a new category
  [HttpPost]
  [ProducesResponseType(StatusCodes.Status201Created)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ApiResponse<CategoryDto>>> CreateCategory([FromBody] CategoryDto categoryDto)
  {
    try
    {
      if (!ModelState.IsValid)
      {
        _logger.LogWarning("Invalid category data provided");
        return BadRequest(new ApiResponse<CategoryDto>
        {
          Success = false,
          ErrorMessage = "Invalid category data",
          Data = null
        });
      }

      _logger.LogInformation("Creating new category: {CategoryName}", categoryDto.CategoryName);
      var category = new Category
      {
        CategoryName = categoryDto.CategoryName,
        Description = categoryDto.Description
      };

      _context.Categories.Add(category);
      await _context.SaveChangesAsync();

      categoryDto.CategoryId = category.CategoryId;

      return CreatedAtAction(
          nameof(GetCategory),
          new { id = category.CategoryId },
          new ApiResponse<CategoryDto>
          {
            Success = true,
            Data = categoryDto
          });
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Failed to create category: {CategoryName}", categoryDto.CategoryName);
      return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<CategoryDto>
      {
        Success = false,
        ErrorMessage = "An error occurred while creating the category"
      });
    }
  }

  // PUT: api/CategoriesPro/{id} - Update an existing category
  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status400BadRequest)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ApiResponse<object>>> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
  {
    try
    {
      if (!ModelState.IsValid)
      {
        _logger.LogWarning("Invalid category data for update with ID {CategoryId}", id);
        return BadRequest(new ApiResponse<object>
        {
          Success = false,
          ErrorMessage = "Invalid category data"
        });
      }

      var existingCategory = await _context.Categories.FindAsync(id);
      if (existingCategory == null)
      {
        _logger.LogWarning("Category with ID {CategoryId} not found for update", id);
        return NotFound(new ApiResponse<object>
        {
          Success = false,
          ErrorMessage = $"Category with ID {id} not found"
        });
      }

      _logger.LogInformation("Updating category with ID {CategoryId}", id);
      existingCategory.CategoryName = categoryDto.CategoryName;
      existingCategory.Description = categoryDto.Description;

      await _context.SaveChangesAsync();

      return NoContent();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Failed to update category with ID {CategoryId}", id);
      return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
      {
        Success = false,
        ErrorMessage = "An error occurred while updating the category"
      });
    }
  }

  // DELETE: api/CategoriesPro/{id} - Remove a category
  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  public async Task<ActionResult<ApiResponse<object>>> DeleteCategory(int id)
  {
    try
    {
      var category = await _context.Categories.FindAsync(id);
      if (category == null)
      {
        _logger.LogWarning("Category with ID {CategoryId} not found for deletion", id);
        return NotFound(new ApiResponse<object>
        {
          Success = false,
          ErrorMessage = $"Category with ID {id} not found"
        });
      }

      _logger.LogInformation("Deleting category with ID {CategoryId}", id);
      _context.Categories.Remove(category);
      await _context.SaveChangesAsync();

      return NoContent();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Failed to delete category with ID {CategoryId}", id);
      return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse<object>
      {
        Success = false,
        ErrorMessage = "An error occurred while deleting the category"
      });
    }
  }
}