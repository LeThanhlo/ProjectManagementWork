namespace Container_App.Model.ProjectUsers
{
    public class ProjectUserModel
    {
        public int ProjectUserId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
