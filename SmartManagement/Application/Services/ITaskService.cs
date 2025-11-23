using SmartManagement.Application.DTOs;

namespace SmartManagement.Application.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDTO> CreateAsync(TaskRequestDTO dto);
        Task<List<TaskResponseDTO>> GetAllAsync();
        Task<TaskResponseDTO?> GetByIdAsync(int id);
        Task<TaskResponseDTO?> UpdateAsync(int id, TaskRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}