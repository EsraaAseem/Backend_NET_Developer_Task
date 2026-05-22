
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.UpdateTaskStatus
{
    public record UpdateTaskStatusCommand(
        UpdateTaskStatusRequestDto Model)
        : IRequest<GenericResponse<string>>;
}
