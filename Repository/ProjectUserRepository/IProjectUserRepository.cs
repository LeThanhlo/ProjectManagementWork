using Container_App.Model.ProjectUsers;

namespace Container_App.Repository.ProjectUserRepository
{
    public interface IProjectUserRepository
    {
        Task AddUserToProjectAsync(ProjectUser projectUser);
        Task<bool> IsUserInProjectAsync(int projectId, int userId);
    }
}
