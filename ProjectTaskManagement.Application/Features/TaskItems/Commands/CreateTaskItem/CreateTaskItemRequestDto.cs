
namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemRequestDto
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }
    }
}
