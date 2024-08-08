using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NotificationApi;

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

app.MapPost("/notifications", (NotificationRequest request) => {

    app.Logger.LogInformation("A request was made for {0}", request.Description); // DUH!
    return TypedResults.NoContent();
});

// app.UseNotificationApi();

app.Run();


public record NotificationRequest 
{
    public string UserSub {get; init;} = string.Empty;
    public string Description {get; init; } = string.Empty;
}