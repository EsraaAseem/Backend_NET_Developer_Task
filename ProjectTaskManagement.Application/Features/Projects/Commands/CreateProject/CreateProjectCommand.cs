
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.CreateProject
{
    public record CreateProjectCommand(
         CreateProjectRequestDto Model)
         : IRequest<GenericResponse<string>>;
}
