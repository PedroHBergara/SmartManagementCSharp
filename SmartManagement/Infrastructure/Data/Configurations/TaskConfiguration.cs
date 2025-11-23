using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartManagement.Domain.Entity;

namespace SmartManagement.Infrastructure.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("TASKS");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("TASK_ID");
            
            builder.Property(t => t.UserId)
                .HasColumnName("USER_ID");

            builder.Property(t => t.Type)
                .HasConversion<string>()
                .HasColumnName("TYPE");
            
            builder.Property(t => t.Title)
                .HasColumnName("TITLE")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType("VARCHAR(500)");
            
            builder.Property(t => t.Due_Date)
                .HasColumnName("DUE_DATE");
            
            builder.Property(t => t.Status)
                .HasColumnName("STATUS")
                .HasConversion<string>()
                .IsRequired();
            
            builder.Property(t => t.CreatedAt)
                .HasColumnName("CREATED_AT")
                .HasColumnType("TIMESTAMP")
                .HasDefaultValueSql("SYSTIMESTAMP");
            
            


        }
    }
}