

namespace ProjectTaskManagement.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectRequestDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
