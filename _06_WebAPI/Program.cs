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