using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HeaderDemoController : ControllerBase
{
  // GET: api/headerdemo
  [HttpGet]
  public IActionResult HeaderDemo()
  {
    var headers = Request.Headers;

    var userAgent = headers["User-Agent"].ToString();
    var accept = headers["Accept"].ToString();
    var authorization = headers["Authorization"].ToString();
    var contentType = headers["Content-Type"].ToString();

    // Set response headers
    Response.Headers["X-User-Agent"] = string.IsNullOrEmpty(userAgent) ? "Not provided" : userAgent;
    Response.Headers["X-Accept"] = string.IsNullOrEmpty(accept) ? "Not provided" : accept;
    Response.Headers["X-Authorization"] = string.IsNullOrEmpty(authorization) ? "Not provided" : authorization;
    Response.Headers["X-Content-Type"] = string.IsNullOrEmpty(contentType) ? "Not provided" : contentType;

    var body = new
    {
      content = "No body, just headers"
    };

    return Ok(body);
  }
}

