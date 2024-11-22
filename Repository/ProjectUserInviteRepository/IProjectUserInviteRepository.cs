using Container_App.Model.ProjectUserInvites;

namespace Container_App.Repository.ProjectUserInviteRepository
{
    public interface IProjectUserInviteRepository
    {
        Task SendInvitesAsync(int projectId, List<int> userIds);
        Task<ProjectUserInviteModel> GetInviteAsync(int inviteId);
        Task AcceptInviteAsync(ProjectUserInviteModel invite);
        Task DeclineInviteAsync(ProjectUserInviteModel invite);
    }
}
