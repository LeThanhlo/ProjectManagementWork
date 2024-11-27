using Container_App.Model.RolePermissions;

namespace Container_App.Repository.RolePermissionsRepository
{
    public interface IRolePermissionsRepository
    {
        Task<int> CreateRolePermission(RolePermission permission);
    }
}
