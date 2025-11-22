using Application.DTOs;
using Application.Mappings;
using Infrastructure.Repositories;
using SmartManagement.Domain.Entity;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        // Create
        public async Task<TaskResponseDTO> CreateAsync(TaskRequestDTO dto)
        {
            var entity = dto.ToEntity();
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            var created = await _repository.CreateAsync(entity);
            return created.ToResponseDTO();
        }

        // Get All
        public async Task<List<TaskResponseDTO>> GetAllAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return tasks.Select(t => t.ToResponseDTO()).ToList();
        }

        // Get By Id
        public async Task<TaskResponseDTO?> GetByIdAsync(int id)
        {
            var task = await _repository.GetByIdAsync(id);
            return task?.ToResponseDTO();
        }

        // Update
        public async Task<TaskResponseDTO?> UpdateAsync(int id, TaskRequestDTO dto)
        {
            var task = await _repository.GetByIdAsync(id);
            if (task == null)
                return null;

            task.UpdateFromDTO(dto);

            await _repository.UpdateAsync(task);

            return task.ToResponseDTO();
        }

        // Delete
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}