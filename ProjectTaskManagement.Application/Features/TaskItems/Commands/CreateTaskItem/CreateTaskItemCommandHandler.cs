
using System.Net;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemCommandHandler
      : IRequestHandler<CreateTaskItemCommand,
          GenericResponse<string>>
    {
        private readonly ITaskItemRepo _taskRepository;
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateTaskItemCommandHandler(
            ITaskItemRepo taskRepository,
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<string>> Handle(
            CreateTaskItemCommand request,
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository
                .GetByIdAsync(request.Model.ProjectId);

            if (project is null)
            {
                return GenericResponse<string>
                    .NotFoundResponse("Project not found");
            }

            if (project.UserId != _currentUserService.UserId)
            {
                return GenericResponse<string>
                    .FailedResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }

            var taskItem = new TaskItem
            {
                Title = request.Model.Title,
                Description = request.Model.Description,
                DueDate = request.Model.DueDate,
                Priority = request.Model.Priority,
                ProjectId = request.Model.ProjectId
            };

            await _taskRepository.AddAsync(taskItem);

            await _taskRepository.SaveChangesAsync();

            return GenericResponse<string>
                .SuccessResponseWithMessage(
                    "Task created successfully");
        }
    }
}
