using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
  [HttpGet]
  public IActionResult English()
  {
    return Ok("Hello World from a Controller");
  }

  [HttpGet("ptbr")]
  public IActionResult Portuguese()
  {
    return Ok("Olá Mundo de um Controlador");
  }

  [HttpGet("hindi")]
  public IActionResult Hindi()
  {
    return Ok("नियंत्रक से हेलो वर्ल्ड");
  }

  [HttpOptions("products")]
  public IActionResult GetOptions()
  {
    Response.Headers.Append("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
    return Ok();
  }

  // GET: Retrieve all products
  [HttpGet("products")]
  public ActionResult<IEnumerable<Product>> GetProducts()
  {
    return Ok(products);
  }

  // GET: Retrieve a single product by ID
  [HttpGet("products/{id}")]
  public ActionResult<Product> GetProduct(int id)
  {
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product == null)
      return NotFound();

    return Ok(product);
  }

  // POST: Add a new product
  [HttpPost("products")]
  public ActionResult<Product> AddProduct([FromBody] Product newProduct)
  {
    newProduct.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
    products.Add(newProduct);
    return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
  }

  // PUT: Update an existing product entirely
  [HttpPut("products/{id}")]
  public ActionResult PutProduct(int id, [FromBody] Product product)
  {
    var existingProduct = products.FirstOrDefault(p => p.Id == id);
    if (existingProduct == null)
      return NotFound();

    existingProduct.Description = product.Description;
    existingProduct.Price = product.Price;
    return NoContent();
  }

  // PATCH: Update an existing product partially
  [HttpPatch("products/{id}")]
  public ActionResult PatchProduct(int id, [FromBody] Product product)
  {
    var existingProduct = products.FirstOrDefault(p => p.Id == id);
    if (existingProduct == null)
      return NotFound();

    if (product.Description != null)
    {
      existingProduct.Description = product.Description;
    }
    if (product.Price.HasValue)
    {
      existingProduct.Price = product.Price.Value;
    }

    return NoContent();
  }

  // DELETE: Remove a product
  [HttpDelete("products/{id}")]
  public ActionResult DeleteProduct(int id)
  {
    var product = products.FirstOrDefault(p => p.Id == id);
    if (product == null)
      return NotFound();

    products.Remove(product);
    return NoContent();
  }

  private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Description = "Notebook", Price = 1200 },
        new Product { Id = 2, Description = "Smartphone", Price = 800 },
        new Product { Id = 3, Description = "Mouse", Price = 50 },
        new Product { Id = 3, Description = "Keyboard", Price = 70 }
    };

}

public class Product
{
  public int? Id { get; set; }
  public string? Description { get; set; }
  public decimal? Price { get; set; }
}
