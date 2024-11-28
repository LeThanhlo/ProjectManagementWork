using Container_App.Model.RolePermissions;
using Container_App.Repository.RolePermissionsRepository;

namespace Container_App.Services.RolePermissionsService
{
    public class RolePermissionsService : IRolePermissionsService
    {
        private readonly IRolePermissionsRepository _rolePermissionsRepository;
        public RolePermissionsService(IRolePermissionsRepository rolePermissionsRepository)
        {
            _rolePermissionsRepository = rolePermissionsRepository;
        }
        public async Task<int> CreateRolePermission(RolePermission permission)
        {
            return await _rolePermissionsRepository.CreateRolePermission(permission);
        }

        public async Task<int> DeleteRolePermission(int roleId)
        {
            return await _rolePermissionsRepository.DeleteRolePermission(roleId);
        }
    }
}
