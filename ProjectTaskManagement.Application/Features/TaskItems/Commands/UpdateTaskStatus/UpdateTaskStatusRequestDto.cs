

using ProjectTaskManagement.Domain.Enums;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusRequestDto
    {
        public int TaskId { get; set; }

        public TaskStatuses Status { get; set; }
    }
}
