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
  * Biometric authentication
  * Two-factor authentication
  * Multifactor authentication

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

Implementation of JWT authentication in an ASP.NET Core Web API.

![JWT Token](images/jwt-token.png)

* The example includes entry points to:
  * Register a new User encryptin the password
  * Login using username and password
  * Access a controller that requires authentication: `[Authorize]` attribute.

### Prerequisites

* Install libaries

  ```shell
  dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
  dotnet add package System.IdentityModel.Tokens.Jwt
  dotnet add package BCrypt.Net-Next
  ```

  * Verify the .csproj file

    ```xml
    ...
    <PackageReference Include="AutoMapper" Version="12.0.1" />
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
    <PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
    ...
    ```

* Create User table

  ````sql
  CREATE TABLE [User] (
      Id INT IDENTITY(1,1) PRIMARY KEY,
      Login VARCHAR(20) NOT NULL UNIQUE,
      Password VARCHAR(255) NOT NULL
  );
  ```

### Configure JWT Authentication

* Add JWT authentication services in `Program.cs` and configure the token validation parameters.

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

* Add JWT settings to `appsettings.json`:
  * `Key`
    * The Key (often referred to as the signing key or secret key) is a secret value used to sign the JWT.
    * This ensures the token's integrity and authenticity.
    * The key is used to create a cryptographic signature for the JWT, which is appended to the token in the Signature part.
    * When a JWT is received, the server uses the same key to verify the signature, ensuring the token hasn’t been tampered with.
    * The key is critical for security, as anyone with access to it can generate or validate tokens.
  * `Issuer`
    * The Issuer (often abbreviated as iss in the JWT payload) identifies the entity that issued the JWT, typically the server or application generating the token.
    * It helps the recipient verify that the token comes from a trusted source.
    * It’s used during token validation to ensure the token was issued by an expected party.
    * The issuer is included in the JWT payload as the iss claim (e.g., "iss": "YourIssuer").
    * When validating a JWT, the server checks if the iss claim matches the expected issuer configured in the application.
  * `Audience`
    * The Audience (abbreviated as aud in the JWT payload) specifies the intended recipient(s) of the JWT, such as a specific API or service.
    * It ensures the token is used only by the intended recipient, preventing misuse by other services or applications.
    * It’s used during token validation to confirm that the token was meant for the validating service.
    * The audience is included in the JWT payload as the aud claim (e.g., "aud": "YourAudience").
    * During validation, the server checks if the aud claim matches the expected audience.
    * In practice, this could be the identifier of the API or service the token is intended for.
  * How These Settings Work Together
    * The JWT consists of three parts: Header, Payload, and Signature, encoded in Base64 and separated by dots (.).
    * The Header specifies the algorithm (e.g., HS256) and token type (JWT).
    * The Payload includes claims like iss (Issuer), aud (Audience), and others (e.g., sub for subject, exp for expiration).
    * The Signature is generated by hashing the Header and Payload with the Key using the specified algorithm.
    * Example:

      ```shell
      eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJZb3VySXNzdWVyIiwiYXVkIjoiWW91ckF1ZGllbmNlIn0.K2wQ3k4z5z7Y9x1z2y3z4x5y6z7x8y9z0a1b2c3d4e5f6g7h8i
      ```

  * Token Validation:
    * The server decodes the JWT and verifies:
      * The Signature using the Key to ensure the token hasn’t been altered.
      * The Issuer matches the expected value (e.g., "YourIssuer").
      * The Audience matches the expected value (e.g., "YourAudience").
      * Other claims like expiration (exp) or not-before (nbf) are valid.
  * Best Practices
    * Key:
      Use a strong, random key (at least 32 bytes for HS256).
      Store it securely (e.g., in environment variables, AWS Secrets Manager, or Azure Key Vault).
      Rotate keys periodically and have a strategy for handling key rotation without invalidating active tokens.
    * Issuer:
      * Use a unique, consistent identifier for your application or server.
      * Validate the issuer on the server to prevent accepting tokens from untrusted sources.
    * Audience:
      * Specify the intended recipient to scope the token’s usage.
      * Validate the audience to prevent token misuse across services.

  ```json
  {
    "Jwt": {
      "Key": "YourSuperSecretKey1234567890123456", // At least 32 characters
      "Issuer": "YourIssuer",
      "Audience": "YourAudience"
    }
  }
  ```

### Define Models

Define models for login, user data and ApiResponseHelper.

```csharp

public class LoginRequest
{
  [Required(ErrorMessage = "Username is required.")]
  [StringLength(20, ErrorMessage = "Username must be 20 characters or less.")]
  public string Username { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required.")]
  [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
  public string Password { get; set; } = string.Empty;
}

public class RegisterRequest
{
  [Required(ErrorMessage = "Login is required.")]
  [StringLength(20, ErrorMessage = "Login must be 20 characters or less.")]
  public string Login { get; set; } = string.Empty;

  [Required(ErrorMessage = "Password is required.")]
  [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]
  public string Password { get; set; } = string.Empty;

  [Required(ErrorMessage = "Confirm password is required.")]
  [Compare("Password", ErrorMessage = "Passwords do not match.")]
  public string ConfirmPassword { get; set; } = string.Empty;
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

### Authentication Controller with Register and Login entry points

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IConfiguration _configuration;
  private readonly NorthWindContext _dbContext;
  private readonly ILogger<CategoriesProController> _logger;

  public AuthController(IConfiguration configuration, NorthWindContext context, ILogger<CategoriesProController> logger)
  {
    _configuration = configuration;
    _dbContext = context ?? throw new ArgumentNullException(nameof(context));
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterRequest request)
  {
    // Validate model using data annotations
    if (!ModelState.IsValid)
    {
      var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
      _logger.LogWarning("Invalid registration. Errors: {Errors}", string.Join(", ", errors));
      return Problem("Invalid input: " + string.Join(", ", errors));
    }

    // Check if login already exists
    if (await _dbContext.Users.AnyAsync(u => u.Login == request.Login))
    {
      _logger.LogWarning("Registration attempt with existing login: {Login}", request.Login);
      return Problem("Login already exists.");
    }

    /*
     * WARNING: Never log password
     */

    // Hash password
    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

    // Create new user
    var user = new User
    {
      Login = request.Login,
      Password = hashedPassword
    };

    // Save to database
    _dbContext.Users.Add(user);
    await _dbContext.SaveChangesAsync();

    _logger.LogInformation("Successful registration for login: {Login}", user.Login);
    return Ok();
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginRequest request)
  {
    // Validate model using data annotations
    if (!ModelState.IsValid)
    {
      var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
      _logger.LogWarning("Invalid login attempt due to model validation errors: {Errors}", string.Join(", ", errors));
      return Problem("Invalid input: " + string.Join(", ", errors));
    }

    // Query the database for the user
    var user = await _dbContext.Users
        .FirstOrDefaultAsync(u => u.Login == request.Username);

    // Check if user exists and verify password
    if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
    {
      _logger.LogWarning("Invalid login attempt for username: {Username}", request.Username);
      return Problem("Invalid username or password.");
    }

    // Generate JWT
    var claims = new[]
    {
      new Claim(ClaimTypes.Name, user.Login),
      new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
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

    _logger.LogInformation("Successful login for username: {Username}", user.Login);
    Response.Headers["jwt-token"] = jwt;
    return Ok();
  }
}
```

### Protected Endpoint

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
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

### Testing the API

1. **Register**:

   ```shell
   curl --location 'http://localhost:5062/api/auth/register' \
   --header 'Content-Type: application/json' \
   --data '{
     "Login": "user3",
     "Password": "Password!123",
     "ConfirmPassword": "Password!123"
   }'
   ```

2. **Login**:

    ```shell
    curl --location 'http://localhost:5062/api/Auth/login' \
    --header 'Content-Type: application/json' \
    --data '{
      "username": "user1",
      "password": "Password!123"
    }'
    ```

3. **Access a secure Controller**:

  ```shell
  curl --location --request GET 'http://localhost:5062/api/User/profile' \
  --header 'Content-Type: application/json' \
  --header 'Authorization: Bearer {{TOKEN_HERE}}' \
  ```

> **Security Alert**: Store the JWT key securely (e.g., in Azure Key Vault or environment variables).

## Best Practices for Authentication in ASP.NET Core

* **Use HTTPS**: Ensure all API communication is encrypted.
* **Validate Tokens**: Use strong token validation parameters (issuer, audience, lifetime).
* **Secure Secrets**: Never hardcode sensitive data like JWT keys in source code.
* **Limit Token Lifetime**: Use short-lived tokens and implement refresh tokens.
* **Use Authorization**: Combine authentication with role-based or policy-based authorization.
* **Log Authentication Events**: Track login attempts and failures for security monitoring.
