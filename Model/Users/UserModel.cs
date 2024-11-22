namespace Container_App.Model.Users
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleGroupId { get; set; }
        public bool IsDel {  get; set; }
    }
}
