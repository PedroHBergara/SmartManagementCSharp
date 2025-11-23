using SmartManagement.Application.DTOs;

namespace SmartManagement.Application.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDTO> CreateAsync(TaskRequestDTO dto);
        Task<List<TaskResponseDTO>> GetAllAsync();
        Task<TaskResponseDTO?> GetByIdAsync(long id);
        Task<TaskResponseDTO?> UpdateAsync(long id, TaskRequestDTO dto);
        Task<bool> DeleteAsync(long id);
    }
}