using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.Permissions
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        public string TableName { get; set; }      
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
