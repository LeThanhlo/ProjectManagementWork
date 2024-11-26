using Container_App.Data;
using Container_App.Model.ProjectUserInvites;

namespace Container_App.Repository.ProjectUserInviteRepository
{
    public class ProjectUserInviteRepository : IProjectUserInviteRepository
    {
        private readonly MyDbContext _context;
        public ProjectUserInviteRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task AcceptInviteAsync(ProjectUserInvite invite)
        {
            invite.Status = 1; // Accepted
            invite.AcceptedAt = DateTime.Now;
            _context.ProjectUserInvites.Update(invite);
            await _context.SaveChangesAsync();
        }

        public async Task DeclineInviteAsync(ProjectUserInvite invite)
        {
            invite.Status = 2; // Declined
            _context.ProjectUserInvites.Update(invite);
            await _context.SaveChangesAsync();
        }

        public async Task<ProjectUserInvite> GetInviteAsync(int inviteId)
        {
            return await _context.ProjectUserInvites.FindAsync(inviteId);
        }

        public async Task SendInvitesAsync(int projectId, List<int> userIds)
        {
            var invites = userIds.Select(userId => new ProjectUserInvite
            {
                ProjectId = projectId,
                UserId = userId,
                Status = 0, // Pending
                SentAt = DateTime.Now
            }).ToList();

            _context.ProjectUserInvites.AddRange(invites);
            await _context.SaveChangesAsync();
        }
    }
}
