using API;
using Application.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

using SmartManagement.Infrastructure.Data; // <-- DbContext

var builder = WebApplication.CreateBuilder(args);

// Banco em memória para testes
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("SmartManagementDB"));

// Repositório
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Serviço
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartManagement API v1");
        options.RoutePrefix = "swagger";
    });
}

// Endpoints
app.MapTaskEndpoints();

app.Run();