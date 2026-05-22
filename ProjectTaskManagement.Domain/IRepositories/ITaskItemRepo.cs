
using ProjectTaskManagement.Domain.Models;

namespace ProjectTaskManagement.Domain.IRepositories
{
    public interface ITaskItemRepo : IRepo<TaskItem>
    {
        Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId);
        Task<TaskItem> GetTaskWithProject(int taskId);
    }
}
