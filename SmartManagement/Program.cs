using SmartManagement.API;
using SmartManagement.Application.Services;
using SmartManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

using SmartManagement.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Banco em memória para testes
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));


builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartManagement API v1");
    options.RoutePrefix = "swagger";
});

// Endpoints
app.MapTaskEndpoints();

app.Run();