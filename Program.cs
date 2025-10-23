using MinimalApi.Infrastructure.Database;
using MinimalApi.DTOs;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = $"server={Environment.GetEnvironmentVariable("MYSQL_HOST")};" +
                       $"port={Environment.GetEnvironmentVariable("MYSQL_PORT")};" +
                       $"database={Environment.GetEnvironmentVariable("MYSQL_DATABASE")};" +
                       $"user={Environment.GetEnvironmentVariable("MYSQL_USER")};" +
                       $"password={Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD")};";

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "admin@test.com" && loginDTO.Password == "1234567")
        return Results.Ok("You're logged in!");
    else
        return Results.Unauthorized();
});

app.Run();