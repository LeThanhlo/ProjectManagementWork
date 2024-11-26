using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.Roles
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
