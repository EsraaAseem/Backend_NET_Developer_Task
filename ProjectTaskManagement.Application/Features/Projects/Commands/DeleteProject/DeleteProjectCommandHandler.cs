
using System.Net;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler
         : IRequestHandler<DeleteProjectCommand,
             GenericResponse<string>>
    {
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteProjectCommandHandler(
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<string>> Handle(
            DeleteProjectCommand request,
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository
                .GetByIdAsync(request.Id);

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

            _projectRepository.Delete(project);

            await _projectRepository.SaveChangesAsync();

            return GenericResponse<string>
                .SuccessResponseWithMessage(
                    "Project deleted successfully");
        }
    }
}
