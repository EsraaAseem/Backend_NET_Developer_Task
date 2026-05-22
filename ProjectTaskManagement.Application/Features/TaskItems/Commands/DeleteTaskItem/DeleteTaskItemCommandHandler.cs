
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.TaskItems.Commands.DeleteTaskItem
{
    public class DeleteTaskItemCommandHandler
         : IRequestHandler<DeleteTaskItemCommand,
             GenericResponse<string>>
    {
        private readonly ITaskItemRepo _taskRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteTaskItemCommandHandler(
            ITaskItemRepo taskRepository,
            ICurrentUserService currentUserService)
        {
            _taskRepository = taskRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<string>> Handle(
            DeleteTaskItemCommand request,
            CancellationToken cancellationToken)
        {
            var taskItem = await _taskRepository
                .GetTaskWithProject(request.TaskId);

            if (taskItem is null)
            {
                return GenericResponse<string>
                    .NotFoundResponse("Task not found");
            }

            if (taskItem.Project.UserId !=
                _currentUserService.UserId)
            {
                return GenericResponse<string>
                    .NotFoundResponse("Unauthorized");
            }

            _taskRepository.Delete(taskItem);

            await _taskRepository.SaveChangesAsync();

            return GenericResponse<string>
                .SuccessResponseWithMessage(
                    "Task deleted successfully");
        }
    }
}
