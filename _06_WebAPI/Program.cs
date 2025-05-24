using System.Net;
using DataAccess.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add database context to services
builder.Services
  .AddDbContext<NorthWindContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
  ));

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(CategoryProfile));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
  options.SuppressModelStateInvalidFilter = true;
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add Swagger services
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo
  {
    Title = "NorthWind API",
    Version = "v1",
    Description = "API for managing categories in the NorthWind database"
  });

  // Optional: Add XML comments for better documentation
  // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
  // c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI(c =>
  {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthWind API v1");
    c.RoutePrefix = string.Empty; // Serve Swagger UI at the root (e.g., /)
  });
}
else
{
  app.UseExceptionHandler(errorApp =>
  {
    errorApp.Run(async context =>
      {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error != null)
        {
          var logger = app.Services.GetRequiredService<ILogger<Program>>();
          logger.LogError(exceptionHandlerPathFeature.Error, "Unhandled exception occurred");

          await context.Response.WriteAsJsonAsync(new
          {
            Success = false,
            ErrorMessage = "An unexpected error occurred. Please try again later."
          });
        }
      });
  });
  app.UseHsts();
}

app.MapControllers();

app.Run();