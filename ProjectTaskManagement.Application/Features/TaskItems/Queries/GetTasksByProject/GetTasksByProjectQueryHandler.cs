
using System.Net;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.TaskItems.Queries.GetTasksByProject
{
    public class GetTasksByProjectQueryHandler
          : IRequestHandler<GetTasksByProjectQuery,
              GenericResponse<IEnumerable<TaskItemResponseDto>>>
    {
        private readonly ITaskItemRepo _taskRepository;
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public GetTasksByProjectQueryHandler(
            ITaskItemRepo taskRepository,
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<
            GenericResponse<IEnumerable<TaskItemResponseDto>>>
            Handle(
                GetTasksByProjectQuery request,
                CancellationToken cancellationToken)
        {
            var project = await _projectRepository
                .GetByIdAsync(request.ProjectId);

            if (project is null)
            {
                return GenericResponse
                    <IEnumerable<TaskItemResponseDto>>
                    .NotFoundResponse("Project not found");
            }

            if (project.UserId !=
                _currentUserService.UserId)
            {
                return GenericResponse
                    <IEnumerable<TaskItemResponseDto>>
                    .FailedResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }

            var tasks = await _taskRepository
                .GetTasksByProjectIdAsync(request.ProjectId);

            var response = tasks.Select(task =>
                new TaskItemResponseDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status.ToString(),
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    ProjectId = task.ProjectId
                });

            return GenericResponse
                <IEnumerable<TaskItemResponseDto>>
                .SuccessResponseWithData(response);
        }
    }
}