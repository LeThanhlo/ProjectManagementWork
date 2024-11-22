using Container_App.Data;
using Container_App.Model.ProjectUsers;
using Microsoft.EntityFrameworkCore;

namespace Container_App.Repository.ProjectUserRepository
{
    public class ProjectUserRepository : IProjectUserRepository
    {
        private readonly MyDbContext _context;
        public ProjectUserRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task AddUserToProjectAsync(ProjectUserModel projectUser)
        {
            _context.ProjectUsers.Add(projectUser);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsUserInProjectAsync(int projectId, int userId)
        {
            return await _context.ProjectUsers.AnyAsync(p => p.ProjectId == projectId && p.UserId == userId);
        }
    }
}
