using Application.DTOs;
using SmartManagement.Domain.Entity;

namespace Application.Mappings
{
    public static class TaskMapping
    {
        // RequestDTO → Entity
        public static TaskEntity ToEntity(this TaskRequestDTO dto)
        {
            return new TaskEntity
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                Status = dto.Status,
                DueDate = dto.DueDate,
            };
        }

        // Entity → ResponseDTO
        public static TaskResponseDTO ToResponseDTO(this TaskEntity entity)
        {
            return new TaskResponseDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Category = entity.Category,
                Status = entity.Status,
                DueDate = entity.DueDate,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        // Update entity from RequestDTO
        public static void UpdateFromDTO(this TaskEntity entity, TaskRequestDTO dto)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Category = dto.Category;
            entity.Status = dto.Status;
            entity.DueDate = dto.DueDate;
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}