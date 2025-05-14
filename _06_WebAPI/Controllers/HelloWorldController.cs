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
}