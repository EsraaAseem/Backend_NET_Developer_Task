using Microsoft.EntityFrameworkCore;
using ProjectTaskManagement.Domain.IRepositories;
using ProjectTaskManagement.Domain.Models;
using ProjectTaskManagement.Presistance.Data;

namespace ProjectTaskManagement.Presistance.Repositories
{
    public class TaskItemRepo : Repo<TaskItem>, ITaskItemRepo
    {
        public TaskItemRepo(AppDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.TaskItems
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }
        public async Task<TaskItem> GetTaskWithProject(int taskId)
        {
            return await _context.TaskItems.Include(t=>t.Project)
                .FirstOrDefaultAsync(t => t.Id == taskId);
        }
    }
}
