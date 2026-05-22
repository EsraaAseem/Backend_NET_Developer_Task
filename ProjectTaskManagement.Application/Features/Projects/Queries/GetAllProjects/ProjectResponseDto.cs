

namespace ProjectTaskManagement.Application.Features.Projects.Queries.GetAllProjects
{
    public class ProjectResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
