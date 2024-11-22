namespace Container_App.Model.ProjectUserInvites
{
    public class ProjectUserInviteModel
    {
        public int InviteId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; } // 0: Pending, 1: Accepted, 2: Declined
        public DateTime SentAt { get; set; }
        public DateTime? AcceptedAt { get; set; }
    }
}
