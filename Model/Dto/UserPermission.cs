namespace Container_App.Model.Dto
{
    public class UserPermission
    {
        public int MenuId { get; set; }
        public bool CanView { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public string TableName { get; set; }
    }
}
