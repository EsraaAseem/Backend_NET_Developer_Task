
using System.Net;
using System.Threading.Tasks;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects;
using ProjectTaskManagement.Application.Features.TaskItems;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler
          : IRequestHandler<GetProjectByIdQuery,
              GenericResponse<GetProjectDtailsDto>>
    {
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetProjectByIdQueryHandler(
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<
            GenericResponse<GetProjectDtailsDto>>
            Handle(
                GetProjectByIdQuery request,
                CancellationToken cancellationToken)
        {
            var project = await _projectRepository
                .GetProjectWithTasksAsync(request.Id);

            if (project is null)
            {
                return GenericResponse<GetProjectDtailsDto>
                    .NotFoundResponse("Project not found");
            }

            if (project.UserId != _currentUserService.UserId)
            {
                return GenericResponse<GetProjectDtailsDto>
                    .FailedResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }

            var response = new GetProjectDtailsDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                Tasks = project.Tasks.Select(task=> new TaskItemResponseDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status.ToString(),
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    ProjectId = task.ProjectId
                }).ToList()
            };

            return GenericResponse<GetProjectDtailsDto>
                .SuccessResponseWithData(response);
        }
    }
}
