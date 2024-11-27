using Container_App.Model.Dto;
using Container_App.Model.Menus;

namespace Container_App.Repository.MenuRepository
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetUserMenus(int userId);
        Task<List<UserPermissionDto>> GetUserPermissions(int userId);
        
        Task<Menu> GetMenu(string menuname);
    }
}
