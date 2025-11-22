using SmartManagement.Domain.Enums;
using DomainTaskStatus = SmartManagement.Domain.Enums.TaskStatus;

namespace SmartManagement.Domain.Entity;

public class TaskEntity
{
    public long Id { get; set; } // TASK_ID

    public long UserId { get; set; } // FK para USERS

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DomainTaskStatus Status { get; set; } = DomainTaskStatus.PENDING;

    public DateTime? DueDate { get; set; }

    public TaskCategory Category { get; set; } = TaskCategory.PERSONAL;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}