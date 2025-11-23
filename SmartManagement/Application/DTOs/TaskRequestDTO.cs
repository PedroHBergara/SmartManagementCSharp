

namespace SmartManagement.Application.DTOs;

public class TaskRequestDTO
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public DateTime? Due_Date { get; set; }
    
    public long Id {get; set; }
    
    public long UserId { get; set; } 
}