using System.ComponentModel.DataAnnotations;

namespace Container_App.Model.Tokens
{
    public class RefreshTokenModel
    {
        [Key]
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; }
        public int UserId { get; set; } // Dùng để liên kết với người dùng
    }
}
