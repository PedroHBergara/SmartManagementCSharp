using SmartManagement.Application.DTOs;
using SmartManagement.Application.Services;

namespace SmartManagement.API
{
    public static class TaskEndpoints
    {
        public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/tasks")
                .WithTags("Tasks"); // Ajuda no Swagger

            // GET ALL
            group.MapGet("/", GetAllTasksHandler);

            // GET BY ID
            group.MapGet("/{id}", GetTaskByIdHandler);

            // CREATE
            group.MapPost("/", CreateTaskHandler); 

            // UPDATE
            group.MapPut("/{id}", UpdateTaskHandler);

            // DELETE
            group.MapDelete("/{id}", DeleteTaskHandler);
        }
        
        internal static async Task<IResult> GetAllTasksHandler(ITaskService service)
        {
            var tasks = await service.GetAllAsync();

            // Adicionamos uma verificação para o caso de não haver tarefas,
            // o que é uma boa prática de API.
            if (tasks == null || !tasks.Any())
            {
                return Results.NoContent(); // Retorna 204 No Content
            }

            return Results.Ok(tasks); // Retorna 200 OK com os dados
        }
        internal static async Task<IResult> GetTaskByIdHandler(long id, ITaskService service)
        {
            var task = await service.GetByIdAsync(id);

            return task is not null ? Results.Ok(task) : Results.NotFound();
        }
        internal static async Task<IResult> CreateTaskHandler(TaskRequestDTO taskDto, ITaskService service)
        {
            var createdTask = await service.CreateAsync(taskDto);

            // Results.Created gera a resposta 201 com o cabeçalho 'Location' e o objeto no corpo.
            return Results.Created($"/tasks/{createdTask.Id}", createdTask);
        }
        internal static async Task<IResult> UpdateTaskHandler(long id, TaskRequestDTO taskDto, ITaskService service)
        {
            var updatedTask = await service.UpdateAsync(id, taskDto);

            return updatedTask is not null ? Results.Ok(updatedTask) : Results.NotFound();
        }
        internal static async Task<IResult> DeleteTaskHandler(long id, ITaskService service)
        {
            var success = await service.DeleteAsync(id);

            return success ? Results.NoContent() : Results.NotFound();
        }
    }
}