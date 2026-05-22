
using MediatR;
using ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects;
using ProjectTaskManagement.Application.ModelsDtos.Commons;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetProjectById
{
    public record GetProjectByIdQuery(int Id)
        : IRequest<GenericResponse<GetProjectDtailsDto>>;
}
