using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.UserRoles
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
