using Container_App.Model.RolePermissions;

namespace Container_App.Services.RolePermissionsService
{
    public interface IRolePermissionsService
    {
        Task<int> CreateRolePermission(RolePermission permission);
        Task<int> DeleteRolePermission(int roleId);
    }
}
