
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public record CreateTaskItemCommand(
       CreateTaskItemRequestDto Model)
       : IRequest<GenericResponse<string>>;
}
