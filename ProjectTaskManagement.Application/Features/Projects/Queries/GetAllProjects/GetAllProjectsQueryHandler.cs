
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler
        : IRequestHandler<GetAllProjectsQuery,
            GenericResponse<IEnumerable<ProjectResponseDto>>>
    {
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetAllProjectsQueryHandler(
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<
            GenericResponse<IEnumerable<ProjectResponseDto>>>
            Handle(
                GetAllProjectsQuery request,
                CancellationToken cancellationToken)
        {
            var projects = await _projectRepository
                .GetUserProjectsAsync(_currentUserService.UserId!);

            var response = projects.Select(project =>
                new ProjectResponseDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    CreatedAt = project.CreatedAt
                });

            return GenericResponse<
                IEnumerable<ProjectResponseDto>>
                .SuccessResponseWithData(response);
        }
    }
}
