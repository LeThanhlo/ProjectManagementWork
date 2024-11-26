using Container_App.Model.Projects;

namespace Container_App.Repository.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<Project> AddProjectAsync(Project project);
        Task<Project> IsLockProjectAsync(int projectId);
    }
}
