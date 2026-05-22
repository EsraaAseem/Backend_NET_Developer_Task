
using MediatR;
using ProjectTaskManagement.Application.Abstrations.IServices.IHelpServices;
using ProjectTaskManagement.Application.ModelsDtos.Commons;
using ProjectTaskManagement.Domain.IRepositories;
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Application.Features.Projects.Commands.CreateProject
{

    public class CreateProjectCommandHandler
        : IRequestHandler<CreateProjectCommand,
            GenericResponse<string>>
    {
        private readonly IProjectRepo _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateProjectCommandHandler(
            IProjectRepo projectRepository,
            ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<string>> Handle(
            CreateProjectCommand request,
            CancellationToken cancellationToken)
        {
            var checkProect = _projectRepository.CheckProjectName(request.Model.Name, _currentUserService.UserId!);
            if(checkProect)
                return GenericResponse<string>
               .BadRequestResponse(
                   "there is another Project with same Name ");
            var project = new Project
            {
                Name = request.Model.Name,
                Description = request.Model.Description,
                CreatedAt = DateTime.UtcNow,
                UserId = _currentUserService.UserId!
            };

            await _projectRepository.AddAsync(project);

            await _projectRepository.SaveChangesAsync();

            return GenericResponse<string>
                .SuccessResponseWithMessage(
                    "Project created successfully");
        }
    }
}
