
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.DeleteProject
{
    public record DeleteProjectCommand(int Id)
         : IRequest<GenericResponse<string>>;
}
