using SmartManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SmartManagement.Infrastructure.Data;

namespace Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskEntity?> GetByIdAsync(long id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<List<TaskEntity>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskEntity> CreateAsync(TaskEntity task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> UpdateAsync(TaskEntity task)
    {
        _context.Tasks.Update(task);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        var rows = await _context.SaveChangesAsync();
        return rows > 0;
    }
}