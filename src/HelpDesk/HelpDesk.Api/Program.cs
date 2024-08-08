using HelpDesk.Api.Todos;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("catalog") ?? throw new Exception();
builder.Services.AddMarten(configuration =>
{
    configuration.Connection(connectionString);
}).UseLightweightSessions();

builder.Services.AddCors(builder =>
{
    builder.AddDefaultPolicy(pol =>
    {

        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
        pol.AllowAnyOrigin();
    });
});


var apiUrl = builder.Configuration.GetConnectionString("notificationApi") ?? throw new Exception("No APi Url");

// Typed Http Client 
builder.Services.AddHttpClient<NotificationHttpClient>(client =>
{
    client.BaseAddress = new Uri(apiUrl);
});
builder.Services.AddScoped<INotifyTodoListStuff>(sp => sp.GetRequiredService<NotificationHttpClient>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.MapControllers();

app.Run();

// the weirdest line of code in the whole class.
public partial class Program { }

