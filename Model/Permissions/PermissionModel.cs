namespace Container_App.Model.Permissions
{
    public class PermissionModel
    {
        public int PermissionId { get; set; }
        public string TableName { get; set; }
        public int RoleGroupId { get; set; }
        public int RoleId { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}
