using Container_App.Model.Projects;

namespace Container_App.Repository.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<int> AddProjectAsync(Project project, int userId);
        Task<bool> IsLockProjectAsync(int projectId);
    }
}
