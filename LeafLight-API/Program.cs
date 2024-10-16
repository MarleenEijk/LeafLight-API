using LeafLight_API.Data;
using LeafLight_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace LeafLight_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseInMemoryDatabase("LeafLightDb")
                );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseCors("MyCors");

            app.MapControllers();

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/users");
            });

            app.Run(); ;
        }
    }
}
