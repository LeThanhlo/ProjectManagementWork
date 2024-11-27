namespace Container_App.Model.Dto
{
    public class UserPermissionDto
    {
        public int MenuId { get; set; }
        public string MenuUrl { get; set; }
        public string MenuName { get; set; } 
        public bool CanView { get; set; } 
        public bool CanAdd { get; set; } 
        public bool CanEdit { get; set; } 
        public bool CanDelete { get; set; }
        public string TableName { get; set; }
    }
}
