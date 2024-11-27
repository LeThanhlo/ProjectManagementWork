using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.RoleMenuAccess
{
    public class RoleMenuAcces
    {
        [Key]
        public int AccessId { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public bool CanAccess { get; set; }
    }
}
