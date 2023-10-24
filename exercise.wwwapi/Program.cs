using exercise.wwwapi.Configuration;
using exercise.wwwapi.EndPoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IConfig, Config>();
builder.Services.AddScoped<IDatabaseRepository<User>, DatabaseRepository<User>>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.ConfigureAuthApi();
app.Run();
