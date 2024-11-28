using Container_App.Model.Dto;
using Container_App.Model.Menus;
using Container_App.Repository.MenuRepository;

namespace Container_App.Services.MenuService
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<Menu> GetMenu(string menuname)
        {
            return await _menuRepository.GetMenu(menuname);
        }

        public async Task<List<Menu>> GetUserMenus(int userId)
        {
            return await _menuRepository.GetUserMenus(userId);
        }

        public async Task<List<UserPermissionDto>> GetUserPermissions(int userId)
        {
            return await _menuRepository.GetUserPermissions(userId);
        }
    }
}
