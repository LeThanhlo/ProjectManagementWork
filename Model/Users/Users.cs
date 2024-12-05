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
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsDel {  get; set; }
    }
}
