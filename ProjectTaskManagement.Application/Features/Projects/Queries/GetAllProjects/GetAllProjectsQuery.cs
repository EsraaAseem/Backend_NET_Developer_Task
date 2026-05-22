
using MediatR;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects
{
    public record GetAllProjectsQuery()
        : IRequest<
            GenericResponse<IEnumerable<ProjectResponseDto>>>;
}
