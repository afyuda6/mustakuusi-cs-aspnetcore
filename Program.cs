using Microsoft.EntityFrameworkCore;
using mustakuusi_cs_aspnetcore.Data;

namespace mustakuusi_cs_aspnetcore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.Use(async (context, next) =>
        {
            if (context.Request.Path == "/robots.txt")
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(@"User-agent: *
Disallow:");
                return;
            }

            await next();
        });

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}