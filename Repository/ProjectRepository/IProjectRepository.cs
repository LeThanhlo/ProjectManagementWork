using Container_App.Model.Projects;

namespace Container_App.Repository.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<ProjectModel> AddProjectAsync(ProjectModel project);
        Task<ProjectModel> IsLockProjectAsync(int projectId);
    }
}
