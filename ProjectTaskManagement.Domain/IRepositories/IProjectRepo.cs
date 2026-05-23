
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Domain.IRepositories
{
    public interface IProjectRepo : IRepo<Project>
    {
        Task<IEnumerable<Project>> GetUserProjectsAsync(string userId);
        Task<Project?> GetProjectWithTasksAsync(int projectId);
        bool CheckProjectName(string name, string userId);
        Task<IEnumerable<Project>> GetProjectsAsync();
    }
}
