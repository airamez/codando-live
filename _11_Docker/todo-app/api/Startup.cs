using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using todo_app.Data;


public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(options =>
            options.UseNpgsql("Host=postgres;Database=todo_db;Username=user;Password=password"));
        
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend",
                builder =>
                {
                    builder.WithOrigins("http://localhost")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });
        
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Ensure database is created
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<TodoContext>();
            context.Database.EnsureCreated();
        }

        app.UseRouting();
        
        app.UseCors("AllowFrontend");

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}