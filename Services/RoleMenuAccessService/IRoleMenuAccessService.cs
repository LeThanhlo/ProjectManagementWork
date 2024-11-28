using Container_App.Model.RoleMenuAccess;

namespace Container_App.Services.RoleMenuAccessService
{
    public interface IRoleMenuAccessService
    {
        Task<int> CreateRoleMenuAccess(RoleMenuAcces roleMenuAccess);
        Task<int> DeleteRoleMenuAccess(int roleId);
    }
}
