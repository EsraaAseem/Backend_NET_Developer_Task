

namespace ProjectTaskManagement.Application.Features.Projects.Commands.CreateProject
{
    public class CreateProjectRequestDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
