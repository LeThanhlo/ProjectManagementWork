using Container_App.Model.ProjectUserInvites;

namespace Container_App.Repository.ProjectUserInviteRepository
{
    public interface IProjectUserInviteRepository
    {
        Task SendInvitesAsync(int projectId, List<int> userIds);
        Task<ProjectUserInvite> GetInviteAsync(int inviteId);
        Task AcceptInviteAsync(ProjectUserInvite invite);
        Task DeclineInviteAsync(ProjectUserInvite invite);
    }
}
