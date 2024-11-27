using Container_App.Model.Roles;

namespace Container_App.Repository.RoleRepository
{
    public interface IRoleRepository
    {
        Task<int> CreateRole(Role role);
    }
}
