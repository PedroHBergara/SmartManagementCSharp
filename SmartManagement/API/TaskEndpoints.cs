using Application.DTOs;
using Application.Services;

namespace API
{
    public static class TaskEndpoints
    {
        public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/tasks")
                .WithTags("Tasks"); // Ajuda no Swagger

            // GET ALL
            group.MapGet("/", async (ITaskService service) =>
            {
                var tasks = await service.GetAllAsync();
                return Results.Ok(tasks);
            });

            // GET BY ID
            group.MapGet("/{id:int}", async (int id, ITaskService service) =>
            {
                var task = await service.GetByIdAsync(id);
                return task is null ? Results.NotFound() : Results.Ok(task);
            });

            // CREATE
            group.MapPost("/", async (TaskRequestDTO dto, ITaskService service) =>
            {
                var created = await service.CreateAsync(dto);
                return Results.Created($"/tasks/{created.Id}", created);
            });

            // UPDATE
            group.MapPut("/{id:int}", async (int id, TaskRequestDTO dto, ITaskService service) =>
            {
                var updated = await service.UpdateAsync(id, dto);
                return updated is null ? Results.NotFound() : Results.Ok(updated);
            });

            // DELETE
            group.MapDelete("/{id:int}", async (int id, ITaskService service) =>
            {
                var deleted = await service.DeleteAsync(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}