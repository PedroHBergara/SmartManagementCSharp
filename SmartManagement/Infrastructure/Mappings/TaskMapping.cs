using SmartManagement.Application.DTOs;
using SmartManagement.Domain.Entity;

namespace SmartManagement.Infrastructure.Mappings
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
                Type = dto.Type,
                Status = dto.Status,
                Due_Date = dto.Due_Date,
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
                Type = entity.Type,
                Status = entity.Status,
                Due_Date = entity.Due_Date,
                CreatedAt = entity.CreatedAt,
                
            };
        }

        // Update entity from RequestDTO
        public static void UpdateFromDTO(this TaskEntity entity, TaskRequestDTO dto)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Type = dto.Type;
            entity.Status = dto.Status;
            entity.Due_Date = dto.Due_Date;
            
        }
    }
}