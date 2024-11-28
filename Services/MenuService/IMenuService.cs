using Container_App.Model.Dto;
using Container_App.Model.Menus;

namespace Container_App.Services.MenuService
{
    public interface IMenuService
    {
        Task<List<Menu>> GetUserMenus(int userId);
        Task<List<UserPermissionDto>> GetUserPermissions(int userId);

        Task<Menu> GetMenu(string menuname);
    }
}
