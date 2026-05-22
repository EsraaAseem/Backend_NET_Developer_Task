
using System.Net;
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler
            : IRequestHandler<UpdateProjectCommand,
                GenericResponse<string>>
    {
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateProjectCommandHandler(
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<string>> Handle(
            UpdateProjectCommand request,
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository
                .GetByIdAsync(request.Model.Id);

            if (project is null)
            {
                return GenericResponse<string>
                    .NotFoundResponse("Project not found");
            }

            if (project.UserId != _currentUserService.UserId)
            {
                return GenericResponse<string>
                    .FailedResponse(HttpStatusCode.Unauthorized,"Unauthorized");
            }

            project.Name = request.Model.Name;
            project.Description = request.Model.Description;

             _projectRepository.Update(project);

            await _projectRepository.SaveChangesAsync();

            return GenericResponse<string>
                .SuccessResponseWithMessage(
                    "Project updated successfully");
        }
    }
}
