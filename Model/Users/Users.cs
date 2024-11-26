using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.Users
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }     
        public bool IsDel {  get; set; }
    }
}
