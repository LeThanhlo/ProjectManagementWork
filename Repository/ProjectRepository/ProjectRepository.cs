using Container_App.Data;
using Container_App.Model.Projects;
using Container_App.utilities;

namespace Container_App.Repository.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly MyDbContext _context;

        public ProjectRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<ProjectModel> AddProjectAsync(ProjectModel project)
        {
            project.Status = (int)StatusProject.Active;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<ProjectModel> IsLockProjectAsync(int projectId)
        {
            var pro = await _context.Projects.FindAsync(projectId);
            if (pro == null) return null;
            pro.Status = (int)StatusProject.Lock;
            await _context.SaveChangesAsync();
            return pro;
        }
    }
}
