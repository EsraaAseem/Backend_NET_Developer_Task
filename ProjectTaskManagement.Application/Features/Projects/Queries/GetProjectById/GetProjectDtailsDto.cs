
using ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects;
using ProjectTaskManagement.Application.Features.TaskItems;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetProjectById
{
    public class GetProjectDtailsDto:ProjectResponseDto
    {
        public List<TaskItemResponseDto> Tasks { get; set; }
    }
}
