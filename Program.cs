var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (MinimalApi.DTOs.LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "admin@test.com" && loginDTO.Password == "1234567")
        return Results.Ok("You're logged in!");
    else
        return Results.Unauthorized();
});

app.Run();