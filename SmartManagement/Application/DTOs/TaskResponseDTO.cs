
namespace SmartManagement.Application.DTOs
{
    public class TaskResponseDTO
    {
        public long Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public DateTime? Due_Date { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}