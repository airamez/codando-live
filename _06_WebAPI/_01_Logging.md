# Logging

Logging is the process of recording information about an application's execution, such as events, errors,
and performance data. Logs help developers debug issues, analyze application behavior, and monitor system health.

## Why is Logging Important?

- **Debugging**: Identifying issues and errors in code.
- **Performance Monitoring**: Analyzing execution time and bottlenecks.
- **Security Auditing**: Tracking unauthorized access or anomalies.
- **Operational Insights**: Understanding user interactions and system status.

## Logging Tools and APIs

There are many Logging Tools and APIS for each programming language or platform
There are the common options for .NET Core

- [Built-in Logging Providers](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-9.0): ASP.NET Core has a built-in logging framework that supports various providers, including Console, Debug, EventLog (Windows), and Azure App Service.
- HTTP Logging Middleware: This logs details about incoming HTTP requests and responses, including headers, status codes, and request paths.
- Third-Party Logging Frameworks:
  - [Serilog](https://serilog.net/): Popular for structured logging and custom sinks.
  - [NLog](https://nlog-project.org/): Flexible and widely used for logging to different outputs.
  - [Log4Net](https://github.com/apache/logging-log4net): A classic choice for .NET applications.
- Middleware-Based Logging: Custom middleware can be used to log every request before it reaches the controller

## Logging in .NET Core

.NET Core provides a built-in logging framework via `Microsoft.Extensions.Logging`. It supports various log levels and multiple providers.

### Installing Logging Dependencies

To use logging in a .NET Core application, ensure the required package is installed:

```sh
dotnet add package Microsoft.Extensions.Logging
```

### Log Levels in .NET Core

.NET Core supports the following log levels:

- **Trace**: Detailed information, mostly for debugging.
- **Debug**: Information helpful for development.
- **Information**: General application flow logs.
- **Warning**: Indications of potential problems.
- **Error**: Runtime errors or unexpected failures.
- **Critical**: Severe problems requiring immediate attention.

### Basic Logging Example

Here’s how to set up logging in a .NET Core Web API:

```csharp
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly ILogger<SampleController> _logger;

    public SampleController(ILogger<SampleController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Processing request at {Time}", DateTime.UtcNow);
        return Ok("Logging example!");
    }
}
```

### Configuring Logging Providers

.NET Core allows multiple logging providers, including:

- **Console Logging**: Outputs logs to the terminal.
- **File Logging**: Writes logs to a file (via Serilog or NLog).
- **Event Logging**: Logs events in Windows Event Viewer.
- **Cloud Logging**: Sends logs to services like Azure Monitor.

Example: Configuring Console Logging in `Program.cs` (ASP.NET Core 6+):

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();
app.Run();
```

## Best Practices for Logging

- Use appropriate log levels to avoid clutter.
- Include contextual information like timestamps and request details.
- Avoid logging sensitive data (e.g., passwords or PII).
- Use structured logging for better analysis.
- Configure log retention to manage storage efficiently.

## Conclusion

Logging is a fundamental aspect of software development, ensuring maintainability, security, and observability. With .NET Core's built-in logging framework and third-party tools like Serilog, developers can implement structured and efficient logging practices.
