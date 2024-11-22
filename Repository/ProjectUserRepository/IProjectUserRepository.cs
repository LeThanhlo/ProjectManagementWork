using Container_App.Model.ProjectUsers;

namespace Container_App.Repository.ProjectUserRepository
{
    public interface IProjectUserRepository
    {
        Task AddUserToProjectAsync(ProjectUserModel projectUser);
        Task<bool> IsUserInProjectAsync(int projectId, int userId);
    }
}
