
using MediatR;
using ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjectsForAdmin
{
    public record GetAllProjectsForAdminQuery : IRequest<
            GenericResponse<IEnumerable<ProjectResponseDto>>>;
}
