var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/software", () =>
{
    var fakeResults = new List<SoftwareItem>()
    {
        new("1", "Destiny 2"),
        new("2", "Jetbrains Rider"),
        new("3", "Neovim")
    };
    return TypedResults.Ok(fakeResults);
});

app.Run();

// the weirdest line of code in the whole class.
public partial class Program { }

public record SoftwareItem(string Id, string Title);