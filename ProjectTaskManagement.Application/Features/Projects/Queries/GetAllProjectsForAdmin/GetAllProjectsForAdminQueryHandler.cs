using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjectsForAdmin
{
    public class GetAllProjectsForAdminQueryHandler : IRequestHandler<GetAllProjectsForAdminQuery,
            GenericResponse<IEnumerable<ProjectResponseDto>>>
    {
        private readonly IProjectRepo _projectRepository;

        public GetAllProjectsForAdminQueryHandler(
            IProjectRepo projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<
            GenericResponse<IEnumerable<ProjectResponseDto>>>
            Handle(
                GetAllProjectsForAdminQuery request,
                CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetProjectsAsync();

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
