namespace Container_App.Model.Roles
{
    public class RoleMenuAccessModel
    {
        public int AccessId { get; set; }
        public int RoleGroupId { get; set; }
        public int MenuId { get; set; }
        public bool CanAccess { get; set; }
    }
}
