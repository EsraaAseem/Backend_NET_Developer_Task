
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.UpdateProject
{
    public record UpdateProjectCommand(
         UpdateProjectRequestDto Model)
         : IRequest<GenericResponse<string>>;
}
