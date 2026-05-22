using Microsoft.EntityFrameworkCore;
using ProjectTaskManagement.Domain.IRepositories;
using ProjectTaskManagement.Domain.Models;
using ProjectTaskManagement.Presistance.Data;

namespace ProjectTaskManagement.Presistance.Repositories
{
    public class ProjectRepo : Repo<Project>, IProjectRepo
    {
        public ProjectRepo(AppDbContext context)
            : base(context)
        {
        }

        public async Task<Project?> GetProjectWithTasksAsync(int projectId)
        {
            return await _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == projectId);
        }
        public bool CheckProjectName(string name, string userId)
        {
            return  _context.Projects
                .Any(p => p.Name== name&&p.UserId==userId);
        }
        public async Task<IEnumerable<Project>> GetUserProjectsAsync(string userId)
        {
            return await _context.Projects
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }
}