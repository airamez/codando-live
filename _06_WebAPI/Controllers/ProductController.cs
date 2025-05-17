using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
  [HttpOptions()]
  public IActionResult Options()
  {
    Response.Headers.Append("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
    return Ok();
  }

  // GET: Retrieve all products
  [HttpGet()]
  public ActionResult<IEnumerable<Product>> GetProducts()
  {
    return Ok(products.Values);
  }

  // GET: Retrieve a single product by ID
  [HttpGet("{id}")]
  public ActionResult<Product> GetProduct(int id)
  {
    if (!products.ContainsKey(id))
      return NotFound();
    return Ok(products[id]);
  }

  // POST: Add a new product
  [HttpPost()]
  public ActionResult<Product> AddProduct([FromBody] Product newProduct)
  {
    newProduct.Id = products.Count > 0 ? products.Max(p => p.Key) + 1 : 1;
    products[newProduct.Id.Value] = newProduct;
    return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
  }

  // PUT: Update an existing product entirely
  [HttpPut("{id}")]
  public ActionResult PutProduct(int id, [FromBody] Product product)
  {
    var existingProduct = products[id];
    if (existingProduct == null)
      return NotFound();
    existingProduct.Description = product.Description;
    existingProduct.Price = product.Price;
    return NoContent();
  }

  // PATCH: Update an existing product partially
  [HttpPatch("{id}")]
  public ActionResult PatchProduct(int id, [FromBody] Product product)
  {
    if (!products.ContainsKey(id))
      return NotFound();
    var existingProduct = products[id];
    if (product.Description != null)
      existingProduct.Description = product.Description;
    if (product.Price.HasValue)
      existingProduct.Price = product.Price.Value;
    return NoContent();
  }

  // DELETE: Remove a product
  [HttpDelete("{id}")]
  public ActionResult DeleteProduct(int id)
  {
    if (!products.ContainsKey(id))
      return NotFound();
    products.Remove(id);
    return NoContent();
  }

  private static Dictionary<int, Product> products = new Dictionary<int, Product>
  {
      { 1, new Product { Id = 1, Description = "Notebook", Price = 1200 } },
      { 2, new Product { Id = 2, Description = "Smartphone", Price = 800 } },
      { 3, new Product { Id = 3, Description = "Mouse", Price = 50 } },
      { 4, new Product { Id = 4, Description = "Keyboard", Price = 70 } }
  };
}

public class Product
{
  public int? Id { get; set; }
  public string? Description { get; set; }
  public decimal? Price { get; set; }
}
