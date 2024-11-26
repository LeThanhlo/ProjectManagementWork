using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.ProjectUsers
{
    public class ProjectUser
    {
        [Key]
        public int ProjectUserId { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
