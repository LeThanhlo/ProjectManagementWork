using Container_App.Model.Projects;

namespace Container_App.Services.ProjectService
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(Project project, int userId);
        Task<Project> IsLockProjectAsync(int projectId);
        Task SendProjectInvitesAsync(int projectId, List<int> userIds);
        Task<bool> AcceptInviteAsync(int inviteId);
        Task<bool> DeclineInviteAsync(int inviteId);
    }
}
