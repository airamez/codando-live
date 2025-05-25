# Authentication in ASP.NET Core Web API

Authentication is the process of verifying the identity of a user or system accessing an application. In the context of a web API, authentication ensures that requests come from legitimate clients (e.g., users, applications, or services) before granting access to protected resources. It answers the question, "Who is the caller?" and is distinct from *authorization*, which determines what the authenticated caller is allowed to do.

* Some links
  * Wikipedia
    * (<https://en.wikipedia.org/wiki/Authentication>)
  * OWASP
    * (<https://cheatsheetseries.owasp.org/cheatsheets/Authentication_Cheat_Sheet.html>)
  * Microsoft
    * (<https://www.microsoft.com/en-us/security/business/security-101/what-is-authentication>)
  * NIST (National Institute of Standard and Technology) - US Department of Commerce
    * (<https://csrc.nist.gov/glossary/term/authentication>)

* Authentication is a extremely complex topic and there are different methods of authentication
  * Password-based authentication
  * Certificate-based authentication
  * Token-based authentication
  * One-time password
  * Push notification
  * Voice authentication
  * Two-factor authentication
  * Multifactor authentication
  * Biometric authentication

## Why Authentication Matters

* **Security**: Protects sensitive data and API endpoints from unauthorized access.
* **Trust**: Ensures that only verified users or systems can interact with the API.
* **Compliance**: Meets regulatory requirements (e.g., GDPR, HIPAA) by securing user data.
* **Personalization**: Enables APIs to tailor responses based on the authenticated user’s identity.

In Web APIs, authentication is typically implemented using middleware that validates credentials (e.g., tokens, cookies, or API keys) and sets the user’s identity for the request.

## Authentication Options

ASP.NET Core supports multiple authentication schemes, each suited to different use cases.

* These are the most common ones:
  * **JWT (JSON Web Token) Authentication**
  * **Cookie-Based Authentication**
  * **OAuth 2.0 and OpenID Connect**
  * **API Key Authentication**
  * **Windows Authentication**

### **JWT (JSON Web Token) Authentication**

* **Description**: [JWT](https://jwt.io/) is a token-based authentication mechanism where a compact, self-contained token encodes user information (claims) and is signed to ensure integrity. The client sends the token in the `Authorization` header (e.g., `Bearer <token>`).
* **Use Case**: Ideal for stateless, scalable APIs, especially in microservices or single-page applications (SPAs).
* **Pros**:
  * Stateless: No server-side session storage needed.
  * Scalable: Works well in distributed systems.
  * Cross-platform: Supported by most frameworks and clients.
* **Cons**:
  * Tokens cannot be revoked easily unless using a blacklist.
  * Token size can increase with many claims.
* **Example Scenario**: A mobile app authenticates users and sends JWTs to access protected API endpoints.

### **Cookie-Based Authentication**

* **Description**: [Cookie-Based Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-9.0) uses HTTP cookies to store authentication data, typically for browser-based applications. ASP.NET Core manages cookies securely with options like SameSite policies.
* **Use Case**: Best for web applications with server-rendered views or SPAs hosted on the same domain as the API.
* **Pros**:
  * Seamless for browser-based apps.
  * Built-in support for secure cookie handling.
* **Cons**:
  * Requires server-side session management (stateful).
  * Vulnerable to CSRF attacks if not configured properly.
* **Example Scenario**: A traditional web app where users log in via a form and receive a session cookie.

### **OAuth 2.0 and OpenID Connect**

* **Description**: [OAuth 2.0](https://www.microsoft.com/en-us/security/business/security-101/what-is-oauth?ef_id=_k_Cj0KCQjw_8rBBhCFARIsAJrc9yCQ_aHKgonhuoOfL0xGSoSKyt-9Y9hXridHUXbYmJfzFHa4qBIMv1EaAh1_EALw_wcB_k_&OCID=AIDcmmdamuj0pc_SEM__k_Cj0KCQjw_8rBBhCFARIsAJrc9yCQ_aHKgonhuoOfL0xGSoSKyt-9Y9hXridHUXbYmJfzFHa4qBIMv1EaAh1_EALw_wcB_k_&gad_source=1&gad_campaignid=21048182046&gbraid=0AAAAADcJh_vAomcfX878OF-KJtDR25uHE&gclid=Cj0KCQjw_8rBBhCFARIsAJrc9yCQ_aHKgonhuoOfL0xGSoSKyt-9Y9hXridHUXbYmJfzFHa4qBIMv1EaAh1_EALw_wcB) is an authorization framework, often paired with OpenID Connect for authentication. It allows users to authenticate via third-party providers (e.g., Google, Microsoft) and receive access tokens.
* **Use Case**: Suitable for APIs that integrate with external identity providers or require delegated access.
* **Pros**:
  * Supports single sign-on (SSO).
  * Leverages trusted identity providers.
  * Flexible for various grant types (e.g., authorization code, client credentials).
* **Cons**:
  * Complex setup compared to JWT.
  * Requires external identity provider integration.
* **Example Scenario**: An API allowing users to log in with their Google account.

### **API Key Authentication**

* **Description**: [API Key Authentication](https://cloud.google.com/endpoints/docs/openapi/when-why-api-key) uses a unique key (string) to authenticate clients, typically sent in headers or query parameters.
* **Use Case**: Common for server-to-server communication or public APIs with limited access.
* **Pros**:
  * Simple to implement.
  * Lightweight for basic use cases.
* **Cons**:
  * Less secure than token-based systems (keys are static).
  * Limited user-specific context.
* **Example Scenario**: A third-party developer accessing a public API with an API key.

### **Windows Authentication**

* **Description**: [Windows Authentication](https://learn.microsoft.com/en-us/windows-server/security/windows-authentication/windows-authentication-overview) leverages Windows credentials for authentication, typically using NTLM or Kerberos.
* **Use Case**: Ideal for intranet applications within a Windows domain.
* **Pros**:
  * Seamless for Windows-based environments.
  * No additional login required for domain users.
* **Cons**:
  * Limited to Windows ecosystems.
  * Not suitable for public-facing APIs.
* **Example Scenario**: An internal corporate API accessed by employees on a Windows network.

## Choosing the Right Authentication Scheme

* **JWT**: Use for stateless APIs, SPAs, or mobile apps.
* **Cookie-Based**: Use for browser-based apps with server-side rendering.
* **OAuth 2.0/OpenID Connect**: Use for third-party integrations or SSO.
* **API Key**: Use for simple server-to-server communication.
* **Windows Authentication**: Use for intranet apps in Windows environments.

## Implementing JWT Authentication in ASP.NET Core Web API

Below is an example of implementing JWT authentication in an ASP.NET Core Web API, using the `ApiResponse<T>` class for consistent responses. This example includes user login to generate a JWT and securing an endpoint with the `[Authorize]` attribute.

### Prerequisites

* Install libaries:

  ```shell
  dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
  dotnet add package System.IdentityModel.Tokens.Jwt
  ```

  * Verify the .csproj file

    ```xml
    ...
    <PackageReference Include="AutoMapper" Version="12.0.1" />
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
    ...
    ```

### Step 1: Define Models

Define models for login, user data and ApiResponseHelper.

```csharp

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
}

public static class ApiResponseHelper
{
  public static ApiResponse<T> Success<T>(T data) => new() { Success = true, Data = data };
  public static ApiResponse<T> Failure<T>(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
}
```

### Step 2: Configure JWT Authentication

Add JWT authentication services in `Program.cs` and configure the token validation parameters.

```csharp
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

Add JWT settings to `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "YourSuperSecretKey1234567890123456", // At least 32 characters
    "Issuer": "YourIssuer",
    "Audience": "YourAudience"
  }
}
```

### Step 3: Create a Login Endpoint

Implement a controller to handle user login and generate JWTs.

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Simulated user validation (replace with real database check)
        if (request.Username != "testuser" || request.Password != "password")
        {
            return Ok(ApiResponseHelper.Failure<UserDTO>("Invalid username or password"));
        }

        // Generate JWT
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, request.Username),
            new Claim(ClaimTypes.NameIdentifier, "1")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        var user = new UserDTO { Id = 1, Username = request.Username };

        return Ok(ApiResponseHelper.Success(new { Token = jwt, User = user }));
    }
}
```

### Step 4: Protect an Endpoint

Create a controller with a protected endpoint using the `[Authorize]` attribute.

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var username = User.Identity?.Name; // From JWT claims
        var user = new UserDTO { Id = 1, Username = username ?? "Unknown" };
        return Ok(ApiResponseHelper.Success(user));
    }
}
```

### Step 5: Testing the API

1. **Login Request**:
   * POST to `/api/auth/login` with body:

     ```json
     {
       "username": "testuser",
       "password": "password"
     }
     ```

   * Response:

     ```json
     {
       "Success": true,
       "Data": {
         "Token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
         "User": {
           "Id": 1,
           "Username": "testuser"
         }
       },
       "ErrorMessage": null
     }
     ```

2. **Access Protected Endpoint**:
   * GET to `/api/users/profile` with header `Authorization: Bearer <token>`.
   * Response:

     ```json
     {
       "Success": true,
       "Data": {
         "Id": 1,
         "Username": "testuser"
       },
       "ErrorMessage": null
     }
     ```

> **Security Alert**: Store the JWT key securely (e.g., in Azure Key Vault or environment variables).

## Best Practices for Authentication in ASP.NET Core

* **Use HTTPS**: Ensure all API communication is encrypted.
* **Validate Tokens**: Use strong token validation parameters (issuer, audience, lifetime).
* **Secure Secrets**: Never hardcode sensitive data like JWT keys in source code.
* **Limit Token Lifetime**: Use short-lived tokens and implement refresh tokens.
* **Use Authorization**: Combine authentication with role-based or policy-based authorization.
* **Log Authentication Events**: Track login attempts and failures for security monitoring.
