

namespace ProjectTaskManagement.Application.Features.TaskItems
{
    public class TaskItemResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public string Status { get; set; }

        public DateTime? DueDate { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }
    }
}
