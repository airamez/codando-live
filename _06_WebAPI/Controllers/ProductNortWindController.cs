using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductNorthWindController : ControllerBase
{
  private readonly NorthWindContext _context;

  public ProductNorthWindController(NorthWindContext context)
  {
    _context = context;
  }

  // GET: api/products - Retrieve all products
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
  {
    try
    {
      var products = await _context.Products
          .ToListAsync();
      return products.Count > 0 ? Ok(products) : NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to retrieve products. Please try again later." });
    }
  }

  // GET: api/products/{id} - Retrieve a single product by ID
  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {
    try
    {
      var product = await _context.Products
          .FirstOrDefaultAsync(p => p.ProductId == id);
      if (product == null)
      {
        return NotFound(new { error = $"Product with ID {id} not found." });
      }
      return Ok(product);
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to retrieve product. Please try again later." });
    }
  }

  // GET: api/products/suppliers - Retrieve all suppliers
  [HttpGet("suppliers")]
  public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
  {
    try
    {
      var suppliers = await _context.Suppliers
          .ToListAsync();
      return suppliers.Count > 0 ? Ok(suppliers) : NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to retrieve suppliers. Please try again later." });
    }
  }

  // GET: api/products/suppliers/{id} - Retrieve a single supplier by ID
  [HttpGet("suppliers/{id}")]
  public async Task<ActionResult<Supplier>> GetSupplier(int id)
  {
    try
    {
      var supplier = await _context.Suppliers
          .FirstOrDefaultAsync(s => s.SupplierId == id);
      if (supplier == null)
      {
        return NotFound(new { error = $"Supplier with ID {id} not found." });
      }
      return Ok(supplier);
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to retrieve supplier. Please try again later." });
    }
  }

  // GET: api/products/categories - Retrieve all categories
  [HttpGet("categories")]
  public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
  {
    try
    {
      var categories = await _context.Categories
          .ToListAsync();
      return categories.Count > 0 ? Ok(categories) : NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to retrieve categories. Please try again later." });
    }
  }

  // GET: api/products/categories/{id} - Retrieve a single category by ID
  [HttpGet("categories/{id}")]
  public async Task<ActionResult<Category>> GetCategory(int id)
  {
    try
    {
      var category = await _context.Categories
          .FirstOrDefaultAsync(c => c.CategoryId == id);
      if (category == null)
      {
        return NotFound(new { error = $"Category with ID {id} not found." });
      }
      return Ok(category);
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to retrieve category. Please try again later." });
    }
  }

  // POST: api/products - Add a new product
  [HttpPost]
  public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
  {
    if (product == null)
    {
      return BadRequest(new { error = "Invalid product data." });
    }

    var validationResults = new List<ValidationResult>();
    var validationContext = new ValidationContext(product);
    if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
    {
      var errors = validationResults.Select(vr => vr.ErrorMessage);
      return BadRequest(new { error = "Validation failed.", details = errors });
    }

    try
    {
      _context.Products.Add(product);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to create product. Please try again later." });
    }
  }

  // PUT: api/products/{id} - Update an existing product
  [HttpPut("{id}")]
  public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
  {
    if (product == null || product.ProductId != id)
    {
      return BadRequest(new { error = "Invalid product data or ID mismatch." });
    }

    var validationResults = new List<ValidationResult>();
    var validationContext = new ValidationContext(product);
    if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
    {
      var errors = validationResults.Select(vr => vr.ErrorMessage);
      return BadRequest(new { error = "Validation failed.", details = errors });
    }

    try
    {
      var existingProduct = await _context.Products.FindAsync(id);
      if (existingProduct == null)
      {
        return NotFound(new { error = $"Product with ID {id} not found." });
      }

      existingProduct.ProductName = product.ProductName;
      existingProduct.SupplierId = product.SupplierId;
      existingProduct.CategoryId = product.CategoryId;
      existingProduct.QuantityPerUnit = product.QuantityPerUnit;
      existingProduct.UnitPrice = product.UnitPrice;
      existingProduct.Discontinued = product.Discontinued;

      await _context.SaveChangesAsync();
      return NoContent();
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to update product. Please try again later." });
    }
  }

  // DELETE: api/products/{id} - Remove a product
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteProduct(int id)
  {
    try
    {
      var product = await _context.Products.FindAsync(id);
      if (product == null)
      {
        return NotFound(new { error = $"Product with ID {id} not found." });
      }

      _context.Products.Remove(product);
      await _context.SaveChangesAsync();
      return NoContent();
    }
    catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && sqlEx.Number == 547)
    {
      // Handle SQL Server error 547: foreign key constraint violation
      return BadRequest(new { error = $"Cannot delete product with ID {id} because it is referenced in other tables." });
    }
    catch (Exception)
    {
      return StatusCode(500, new { error = "Failed to delete product. Please try again later." });
    }
  }
}