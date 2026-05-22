

using ProjectTaskManagement.Domain.Enums;

namespace ProjectTaskManagement.Domain.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string? Description { get; set; }

        public TaskStatuses Status { get; set; } = TaskStatuses.ToDo;

        public DateTime DueDate { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}
