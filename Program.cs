var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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

public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}