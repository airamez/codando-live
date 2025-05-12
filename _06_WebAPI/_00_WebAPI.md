# WebAPI ASP.NET Core

## Definition

A WebAPI in ASP.NET Core is a framework for building HTTP services that can be consumed by web applications, mobile apps, or other services. It follows RESTful principles and is lightweight, making it ideal for microservices and backend communication.

* Interesting Sources
  * [APIs with ASP.NET Core](https://dotnet.microsoft.com/en-us/apps/aspnet/apis)
  * [Build a web API with minimal API, ASP.NET Core, and .NET](https://learn.microsoft.com/en-us/training/modules/build-web-api-minimal-api/?WT.mc_id=dotnet-35129-website)
    * FREE COURSE
  * [Minimal APIs overview](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website)

## MVC

The [**Model-View-Controller (MVC)**](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-9.0) pattern is a software design architecture that separates an application into three main components:

1. **Model**: Represents the data and business logic.
2. **View**: Handles UI presentation (not relevant in WebAPI).
3. **Controller**: Manages user requests and acts as an intermediary between the Model and View.

![Postman](images/mvc.png)

ASP.NET Core WebAPI primarily focuses on **Controllers**, where requests are processed and responses are sent in formats like JSON.

* Create a WebAPI project and add to the solution

  ```shell
  # Create the WebAPI project
  dotnet new webapi -n WEB_API_PROJECT_NAME # This one will have a WeatherForecast demo content

  # Creates an empty one
  dotnet new empty -n WEB_API_PROJECT_NAME

  # Add the WebAPI project to the solution
  dotnet sln add folder/WEB_API_PROJECT_NAME.csproj

  # List all projects
  dotnet sln list
  ```

* Create a Controller

  ```shell
  dotnet new apicontroller -n HelloWorldController -o Controllers
  ```

  ```csharp
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
  ```

* Start the WebAPI Application

  ```shell
  dotnet run
  ```

* Acessing the Controller
  * Using the browser  

    ```shell
    http://localhost:<port>/api/HelloWorld
    ```

  * Using Postman
    * [Postman](https://www.postman.com/) is the single platform for designing, building, and scaling APIs—together. Join over 40 million users who have consolidated their workflows and leveled up their API game—all in one powerful platform.

    ![Postman](images/Postman.png)

  * Using cURL
    * [curl](https://curl.se/) is used in command lines or scripts to transfer data
    * curl is free and open source software and exists thanks to thousands of contributors and our awesome sponsors. The curl project follows well established open source best practices. You too can help us improve!

    ```shell
    curl -X GET http://localhost:5062/api/HelloWorld
    ```

## HTTP - Hyper Text Transger Protocol

[**HTTP (HyperText Transfer Protocol)**](https://en.wikipedia.org/wiki/HTTP) is the foundation of communication on the web. It allows clients (such as browsers or APIs) to interact with servers by sending requests and receiving responses.

* Every HTTP interaction follows this structure:
  1. **Client sends a request** (e.g., browser or API call).
  2. **Server processes the request** and generates a response.
  3. **Server responds** with data and a status code.

* [HTTP Methods](https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Methods)

  | Method   | **Description**                |
  |----------|--------------------------------|
  | `GET`    | Retrieve data                  |
  | `POST`   | Send new data to the server    |
  | `PUT`    | Update existing data           |
  | `DELETE` | Remove a resource              |
  | `PATCH`  | Partially update a resource    |
  | `OPTIONS`| Retrieve supported methods for the resource |
  | `HEAD`   | Retrieve only headers, without the response body |
  | `TRACE`  | Debugging tool that shows the request journey |

## What Happens on an HTTP Request

When a client (such as a web browser) sends an [HTTP request](https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/Overview),
a series of steps occur to ensure communication between the client and the server. Here's a breakdown of the process:

1. **Client Initiates Request**  
   * A user interacts with a webpage by clicking a link or entering a URL.
   * The browser constructs an HTTP request with headers, method (GET, POST, etc.), and optional body content.

2. **DNS Resolution**  
   * The browser checks its cache or asks a DNS server to resolve the domain name into an IP address.

3. **Establishing a TCP Connection**  
   * Using the resolved IP address, the browser establishes a TCP connection with the server through a handshake.

4. **Sending the HTTP Request**  
   * The client sends the HTTP request to the server, specifying details such as the requested resource and additional headers.

5. **Server Processes Request**  
   * The server parses the request and determines how to respond.
   * If the resource is found, it processes the request and generates an appropriate response.
   * If the resource is not found or there's an error, the server returns an HTTP status code.

6. **Sending the HTTP Response**  
   * The server sends back an HTTP response containing headers, a status code (such as `200 OK` or `404 Not Found`), and the requested data (body).

7. **Client Receives and Renders Response**  
   * The browser receives the response and processes the content.
   * If the response contains HTML, CSS, or JavaScript, it renders the webpage accordingly.

8. **Connection Handling & Optimization**  
   * Persistent connections may keep the TCP session open for additional requests.
   * Modern browsers use techniques like caching and compression to optimize performance.

* Understanding this process is crucial for debugging issues and optimizing web applications!

> This is a very common quest on Interviews

## HTTP Headers

HTTP headers are key-value pairs included in requests and responses, providing additional context and instructions about the communication between a client and a server. They influence caching, authentication, security, and content processing.

* HTTP Headers types
  * Request Headers
    * Sent by the client to provide details about the request, such as the expected response format or authentication credentials.
    * `User-Agent`: Identifies the client (e.g., browser type, operating system).
    * `Accept`: Specifies the preferred media types (e.g., `text/html`, `application/json`).
    * `Authorization`: Contains authentication credentials, such as API keys or tokens.
    * `Referer`: Indicates the previous webpage that led to the request.
  * Response Headers
    * Sent by the server to provide additional information about the response.
    * `Content-Type`: Specifies the format of the response (e.g., `application/json`, `text/html`).
    * `Server`: Identifies the server software handling the request.
    * `Set-Cookie`: Used to send cookies to the client for session management.
    * `Cache-Control`: Determines caching policies for the response.
  * General Headers
    * Used in both requests and responses, providing communication-related metadata.
    * `Date`: Indicates the timestamp when the request or response was created.
    * `Connection`: Controls connection persistence (e.g., `keep-alive` to maintain open connections).
    * `Content-Length`: Specifies the size of the response body in bytes.
* Importance of Headers
  * **Security**: Authentication and encryption headers ensure secure data exchange.
  * **Performance**: Headers like `Cache-Control` help optimize resource loading.
  * **Customization**: Developers use headers to tailor request behavior for APIs and web applications.
* Understanding HTTP headers allows developers to fine-tune communication between clients and servers, ensuring efficient and secure web interactions.

## HTTP Status Codes

HTTP status codes are **standardized responses** used by servers to indicate the result of an API request.  
They are grouped into categories:

| **Range** | **Category**  | **Meaning** |
|-----------|---------------|-------------|
| **1xx**   | Informational | Request received, continuing process |
| **2xx**   | Success       | Request was successfully processed |
| **3xx**   | Redirection   | Further action needed to complete request |
| **4xx**   | Client Error  | Request has an issue from the user's side |
| **5xx**   | Server Error  | Something went wrong on the server |

### Common HTTP Status Codes & Their Usage

| **Status Code** | **Description** | **Example Usage in ASP.NET Core** |
|-----------------|-----------------|-----------------------------------|
| **200 OK** | Request successful, returning data | `return Ok("Success!");` |
| **201 Created** | Resource successfully created | `return Created("/api/resource/1", newResource);` |
| **204 No Content** | Request successful, but no response body | `return NoContent();` |
| **400 Bad Request** | Invalid client request | `return BadRequest("Invalid input!");` |
| **401 Unauthorized** | Missing or invalid authentication | `return Unauthorized();` |
| **403 Forbidden** | Client lacks necessary permissions | `return Forbid();` |
| **404 Not Found** | Resource not found | `return NotFound("Item not found");` |
| **500 Internal Server Error** | Server encountered an issue | `return StatusCode(500, "An error occurred");` |

## The anatomy of the `HelloWorldController`

  ```csharp
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
  ```

  1. The controller inheriting from ControllerBase, which is optimized for APIs.
  2. `[Route("api/[controller]")]` sets the base URL to `api/HelloWorld`, dynamically resolving [controller] to HelloWorld.
     The URL does not need the sufix Controller
  3. `[ApiController]` enables automatic API-specific behaviors, such as model validation.
  4. `[HttpGet]` indicates this method handles GET requests.
  5. The method name (`Get`) is just a convention to help understand what the method does

* What happen when the `http://localhost:5062/api/HelloWorld` url is accessed
  1. ASP.NET matches the controller's route (api/HelloWorld).
  2. The framework looks for methods with [HttpGet] inside HelloWorldController.
  3. The Get() method executes because it has [HttpGet] defined.
  4. The method returns "Hello World from a Controller" as a response.

## Implementing a Controller using Entity Framework

* Adding a reference to the DataAccess project

  ```shell
  dotnet add reference ../_05_DataAccess/DataAccess.csproj
  ```

* Add the String Connection to the appsettings.json
* Add the Context to the Application Services in the `Program.cs` file

  ```csharp
  using DataAccess.Models;
  using Microsoft.EntityFrameworkCore;

  var builder = WebApplication.CreateBuilder(args);

  // Add database context to services
  builder.Services
    .AddDbContext<NorthWindContext>(options => options.UseSqlServer(
      builder.Configuration.GetConnectionString("DefaultConnection")
    ));

  builder.Services.AddControllers();

  var app = builder.Build();

  if (app.Environment.IsDevelopment())
  {
  }

  app.MapControllers();

  app.Run();
  ```

* Creating a Controller: `CategoryController.cs`

  ```csharp
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
        return StatusCode(500, $"Database error: {ex.Message}");
      }
    }
    ...
  ```

* Testing the API Endpoints

  * Get all Categories

    ```shell
    curl --location 'http://localhost:5062/api/categories'
    ```

  * Get a Category

    ```shell
    curl --location 'http://localhost:5062/api/categories/5'
    ```

  * Add a Category

    ```shell
    curl --location 'http://localhost:5062/api/categories' \
    --header 'Content-Type: application/json' \
    --data '{
        "CategoryName": "Electronics", 
        "Description": "Devices and gadgets"
    }'
    ```

  * Update a Category

    ```shell
    curl --location --request PUT 'http://localhost:5062/api/categories/1' \
    --header 'Content-Type: application/json' \
    --data '{
        "CategoryName": "Beverages.", 
        "Description": "Devices and gadgets."
    }'
    ```

  * Delete a Category
  
    ```shell
      curl --location --request DELETE 'http://localhost:5062/api/categories/9' \
    --header 'Content-Type: application/json' \
    --data '{
        "CategoryName": "Beverages [UPDATED]", 
        "Description": "Devices and gadgets [UPDATED]"
    }'
    ```
