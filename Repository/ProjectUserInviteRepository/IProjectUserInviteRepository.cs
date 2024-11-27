using Container_App.Model.ProjectUserInvites;

namespace Container_App.Repository.ProjectUserInviteRepository
{
    public interface IProjectUserInviteRepository
    {
        Task<int> SendInvitesAsync(int projectId, List<int> userIds);
        Task<ProjectUserInvite> GetInviteAsync(int inviteId);
        Task<int> AcceptInviteAsync(ProjectUserInvite invite);
        Task<int> DeclineInviteAsync(ProjectUserInvite invite);
    }
}
