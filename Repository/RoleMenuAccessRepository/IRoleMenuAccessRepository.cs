using Container_App.Model.RoleMenuAccess;

namespace Container_App.Repository.RoleMenuAccessRepository
{
    public interface IRoleMenuAccessRepository
    {
        Task<int> CreateRoleMenuAccess (RoleMenuAcces roleMenuAccess);
    }
}
