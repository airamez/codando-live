using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QueryStringController : ControllerBase
{
  [HttpGet()]
  public IActionResult Get()
  {
    var category = HttpContext.Request.Query["category"];
    var minPrice = HttpContext.Request.Query["minPrice"];
    var sortBy = HttpContext.Request.Query["sortBy"];

    return Ok($"Category: {category}, Min Price: {minPrice}, Sorted By: {sortBy}");
  }

  [HttpGet("with-params")]
  public IActionResult GetWithParams(string category, decimal minPrice = 0, string sortBy = "name")
  {
    return Ok($"Category: {category}, Min Price: {minPrice}, Sorted By: {sortBy}");
  }
}