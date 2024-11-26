using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.Roles
{
    public class RoleMenuAccess
    {
        [Key]
        public int AccessId { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool CanAccess { get; set; }
    }
}
