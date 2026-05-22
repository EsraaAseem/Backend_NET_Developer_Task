
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.DeleteTaskItem
{
    public record DeleteTaskItemCommand(int TaskId)
         : IRequest<GenericResponse<string>>;
}
