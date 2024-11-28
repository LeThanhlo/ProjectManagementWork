using Container_App.Model.Roles;

namespace Container_App.Services.RoleService
{
    public interface IRoleService
    {
        Task<int> CreateRole(Role role);
        Task<int> DeleteRole(int RoleId);
    }
}
