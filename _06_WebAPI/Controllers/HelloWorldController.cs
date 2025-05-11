using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HelloWorldController : ControllerBase
{
  [HttpGet]
  public string Get()
  {
    return "Hello World from a Controller";
  }
}