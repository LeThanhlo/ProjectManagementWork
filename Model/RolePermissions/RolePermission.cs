using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.RolePermissions
{
    public class RolePermission
    {
        [Key]
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
    }
}
