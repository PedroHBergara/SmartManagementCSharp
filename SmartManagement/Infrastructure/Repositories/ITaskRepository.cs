using SmartManagement.Domain.Entity;
using SmartManagement.Domain.Enums;

namespace SmartManagement.Infrastructure.Repositories;

public interface ITaskRepository
{
    Task<TaskEntity?> GetByIdAsync(long id);
    Task<List<TaskEntity>> GetAllAsync();
    Task<TaskEntity> CreateAsync(TaskEntity task);
    Task<bool> UpdateAsync(TaskEntity task);
    Task<bool> DeleteAsync(long id);
}