// SmartManagement.Tests/API/TaskEndpointsTests.cs

using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using SmartManagement.API;
using SmartManagement.Application.Services;
using SmartManagement.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class TaskEndpointsTests
{
    private readonly Mock<ITaskService> _mockService;

    public TaskEndpointsTests()
    {
        _mockService = new Mock<ITaskService>();
    }

    [Fact]
    public async Task GetAllTasksHandler_ShouldReturnOkWithTasks_WhenTasksExist()
    {
        
        var fakeTaskResponseDtos = new List<TaskResponseDTO>
        {
            new TaskResponseDTO { Id = 1, Title = "Test Task 1", Description = "Description 1", Status = "PENDING" },
            new TaskResponseDTO { Id = 2, Title = "Test Task 2", Description = "Description 2", Status = "IN_PROGRESS"}
        };

        _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(fakeTaskResponseDtos);

        // Act
        var result = await TaskEndpoints.GetAllTasksHandler(_mockService.Object);

        // Assert
       
        result.Should().BeOfType<Ok<List<TaskResponseDTO>>>(); 
        
        var okResult = result as Ok<List<TaskResponseDTO>>; 
        okResult.Value.Should().NotBeNull();
        okResult.Value.Should().BeEquivalentTo(fakeTaskResponseDtos);
    }

    [Fact]
    public async Task GetAllTasksHandler_ShouldReturnNoContent_WhenNoTasksExist()
    {
        // Arrange
      
        _mockService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<TaskResponseDTO>());

        // Act
        var result = await TaskEndpoints.GetAllTasksHandler(_mockService.Object);

        // Assert
        result.Should().BeOfType<NoContent>();
    }
    [Fact]
    public async Task GetTaskByIdHandler_ShouldReturnOkWithTask_WhenTaskExists()
    {
        // Arrange
        // 1. Crie um ID e um DTO falsos para o cenário de sucesso.
        const int existingId = 1;
        var fakeTaskDto = new TaskResponseDTO { Id = existingId, Title = "Existing Task", Description = "A task that exists.", Status = "IN_PROGRESS" };

        // 2. Configure o mock: Quando GetByIdAsync for chamado com 'existingId',
        //    ele deve retornar o DTO falso.
        _mockService.Setup(service => service.GetByIdAsync(existingId)).ReturnsAsync(fakeTaskDto);

        // Act
        // 3. Chame o handler do endpoint com o ID e o serviço mockado.
        var result = await TaskEndpoints.GetTaskByIdHandler(existingId, _mockService.Object);

        // Assert
        // 4. Verifique se o resultado é um 200 OK.
        result.Should().BeOfType<Ok<TaskResponseDTO>>();

        // 5. Verifique se o conteúdo retornado é exatamente o DTO que esperamos.
        var okResult = result as Ok<TaskResponseDTO>;
        okResult!.Value.Should().BeEquivalentTo(fakeTaskDto);
    }

    [Fact]
    public async Task GetTaskByIdHandler_ShouldReturnNotFound_WhenTaskDoesNotExist()
    {
        // Arrange
        // 1. Defina um ID que não existe.
        const int nonExistingId = 99;

        // 2. Configure o mock: Quando GetByIdAsync for chamado com 'nonExistingId',
         _mockService.Setup(service => service.GetByIdAsync(nonExistingId)).ReturnsAsync((TaskResponseDTO)null);

        // Act
       
        var result = await TaskEndpoints.GetTaskByIdHandler(nonExistingId, _mockService.Object);

        // Assert
       
        result.Should().BeOfType<NotFound>();
    }
    [Fact]
    public async Task CreateTaskHandler_ShouldReturnCreated_WithLocationHeaderAndTaskBody()
    {
        // Arrange
        // 1. Crie o DTO de requisição que o cliente enviaria.
        var requestDto = new TaskRequestDTO
        {
            Title = "New Task via Test",
            Description = "A description for the new task."
        };
        // 2. Crie o DTO de resposta que o serviço DEVE retornar após a criação.
        //    Ele é parecido, mas já tem um ID.
        var responseDto = new TaskResponseDTO { Id = 10, Title = requestDto.Title, Description = requestDto.Description, Status ="PENDING" };

        // 3. Configure o mock: Quando CreateAsync for chamado com QUALQUER TaskRequestDTO,
        //    ele deve retornar o nosso DTO de resposta falso.
        //    Usamos It.IsAny<T>() porque não nos importamos em comparar o objeto exato.
        _mockService.Setup(service => service.CreateAsync(It.IsAny<TaskRequestDTO>()))
            .ReturnsAsync(responseDto);

        // Act
        // 4. Chame o handler, passando o DTO de requisição e o serviço mockado.
        var result = await TaskEndpoints.CreateTaskHandler(requestDto, _mockService.Object);

        // Assert
        // 5. Verifique se o resultado é do tipo 'Created<T>', que representa um 201 Created.
        result.Should().BeOfType<Created<TaskResponseDTO>>();

        // 6. Extraia o resultado para verificações mais detalhadas.
        var createdResult = result as Created<TaskResponseDTO>;

        // 7. Verifique se o corpo da resposta contém a tarefa criada que o serviço retornou.
        createdResult!.Value.Should().BeEquivalentTo(responseDto);

        // 8. Verifique se o cabeçalho 'Location' foi gerado corretamente.
        createdResult.Location.Should().Be($"/tasks/{responseDto.Id}");
    }
    [Fact]
public async Task UpdateTaskHandler_ShouldReturnOkWithUpdatedTask_WhenTaskExists()
{
    // Arrange
    // 1. Defina o ID e os dados de atualização.
    const int existingId = 1;
    var requestDto = new TaskRequestDTO
    {
        Title = "Updated Title",
        Description = "Updated Description"
    };

    // 2. Crie o DTO de resposta que o serviço deve retornar.
    var responseDto = new TaskResponseDTO
    {
        Id = existingId,
        Title = requestDto.Title,
        Description = requestDto.Description,
        Status ="IN_PROGRESS" // O status pode ter sido alterado pela lógica de negócio
    };

    // 3. Configure o mock: Quando UpdateAsync for chamado com o ID e qualquer DTO,
    //    ele deve retornar o DTO de resposta simulado.
    _mockService.Setup(service => service.UpdateAsync(existingId, It.IsAny<TaskRequestDTO>()))
                .ReturnsAsync(responseDto);

    // Act
    // 4. Chame o handler com os dados de teste.
    var result = await TaskEndpoints.UpdateTaskHandler(existingId, requestDto, _mockService.Object);

    // Assert
    // 5. Verifique se o resultado é um 200 OK.
    result.Should().BeOfType<Ok<TaskResponseDTO>>();

    // 6. Verifique se o corpo da resposta contém a tarefa atualizada.
    var okResult = result as Ok<TaskResponseDTO>;
    okResult!.Value.Should().BeEquivalentTo(responseDto);
}

[Fact]
public async Task UpdateTaskHandler_ShouldReturnNotFound_WhenTaskDoesNotExist()
{
    // Arrange
    // 1. Defina um ID que não existe e um DTO qualquer.
    const int nonExistingId = 99;
    var requestDto = new TaskRequestDTO { Title = "Any", Description = "Any" };

    // 2. Configure o mock: Quando UpdateAsync for chamado com o ID inexistente,
    //    ele deve retornar null.
    _mockService.Setup(service => service.UpdateAsync(nonExistingId, It.IsAny<TaskRequestDTO>()))
                .ReturnsAsync((TaskResponseDTO)null);

    // Act
    // 3. Chame o handler.
    var result = await TaskEndpoints.UpdateTaskHandler(nonExistingId, requestDto, _mockService.Object);

    // Assert
    // 4. Verifique se o resultado é um 404 Not Found.
    result.Should().BeOfType<NotFound>();
}
[Fact]
public async Task DeleteTaskHandler_ShouldReturnNoContent_WhenTaskExistsAndIsDeleted()
{
    // Arrange
    // 1. Defina um ID que existe.
    const int existingId = 1;

    // 2. Configure o mock: Quando DeleteAsync for chamado com o ID existente,
    //    deve retornar 'true', indicando sucesso na exclusão.
    _mockService.Setup(service => service.DeleteAsync(existingId)).ReturnsAsync(true);

    // Act
    // 3. Chame o handler com o ID.
    var result = await TaskEndpoints.DeleteTaskHandler(existingId, _mockService.Object);

    // Assert
    // 4. Verifique se o resultado é um 204 No Content.
    result.Should().BeOfType<NoContent>();
}

[Fact]
public async Task DeleteTaskHandler_ShouldReturnNotFound_WhenTaskDoesNotExist()
{
    // Arrange
    // 1. Defina um ID que não existe.
    const int nonExistingId = 99;

    // 2. Configure o mock: Quando DeleteAsync for chamado com o ID inexistente,
    //    deve retornar 'false'.
    _mockService.Setup(service => service.DeleteAsync(nonExistingId)).ReturnsAsync(false);

    // Act
    // 3. Chame o handler com o ID.
    var result = await TaskEndpoints.DeleteTaskHandler(nonExistingId, _mockService.Object);

    // Assert
    // 4. Verifique se o resultado é um 404 Not Found.
    result.Should().BeOfType<NotFound>();
}
    
}
