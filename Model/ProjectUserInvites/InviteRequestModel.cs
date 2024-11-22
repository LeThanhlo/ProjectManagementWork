namespace Container_App.Model.ProjectUserInvites
{
    public class InviteRequestModel
    {
        public int ProjectId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
