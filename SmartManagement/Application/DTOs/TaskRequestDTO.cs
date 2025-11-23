using Status = SmartManagement.Domain.Enums.TaskStatus;
using Category = SmartManagement.Domain.Enums.TaskCategory;

namespace SmartManagement.Application.DTOs;

public class TaskRequestDTO
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Category Category { get; set; }
    public Status Status { get; set; }
    public DateTime? Due_Date { get; set; }
}