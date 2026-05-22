
using System.Net;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.Enums;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommandHandler
         : IRequestHandler<UpdateTaskStatusCommand,
             GenericResponse<string>>
    {
        private readonly ITaskItemRepo _taskRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateTaskStatusCommandHandler(
            ITaskItemRepo taskRepository,
            ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<string>> Handle(
            UpdateTaskStatusCommand request,
            CancellationToken cancellationToken)
        {
            var taskItem = await _taskRepository
                .GetTaskWithProject(request.Model.TaskId);

            if (taskItem is null)
            {
                return GenericResponse<string>
                    .NotFoundResponse("Task not found");
            }

            if (taskItem.Project.UserId !=
                _currentUserService.UserId)
            {
                return GenericResponse<string>
                    .FailedResponse(HttpStatusCode.Unauthorized, "Unauthorized");
            }

            taskItem.Status =request.Model.Status;

             _taskRepository.Update(taskItem);

            await _taskRepository.SaveChangesAsync();

            return GenericResponse<string>
                .SuccessResponseWithMessage(
                    "Task status updated successfully");
        }
    }
}
