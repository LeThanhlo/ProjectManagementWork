using Container_App.Model.Menus;

namespace Container_App.Model.Dto
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public List<Menu> Menus { get; set; } // Danh sách menu
        public List<UserPermissionDto> Permissions { get; set; }
    }
}
