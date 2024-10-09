namespace LeafLight_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllers();

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/plants");
            });

            app.Run(); ;
        }
    }
}
