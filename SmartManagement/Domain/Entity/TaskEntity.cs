
namespace SmartManagement.Domain.Entity;

public class TaskEntity
{
    public long Id { get; set; } // TASK_ID

    public long UserId { get; set; } // FK para USERS

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Status { get; set; }

    public DateTime? Due_Date { get; set; }

    public string Type { get; set; }

    public DateTime CreatedAt { get; set; }
    
}