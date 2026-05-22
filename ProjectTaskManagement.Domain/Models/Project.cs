

namespace ProjectTaskManagement.Domain.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; } = default!;

        public AppUser User { get; set; } = default!;

        public ICollection<TaskItem> Tasks { get; set; } 
    }
}
