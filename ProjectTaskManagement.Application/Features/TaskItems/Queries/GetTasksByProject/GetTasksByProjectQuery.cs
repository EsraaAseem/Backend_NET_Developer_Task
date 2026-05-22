
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.TaskItems.Queries.GetTasksByProject
{
    public record GetTasksByProjectQuery(int ProjectId)
         : IRequest<
             GenericResponse<IEnumerable<TaskItemResponseDto>>>;
}
