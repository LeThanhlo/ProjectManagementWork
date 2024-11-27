using Container_App.Model.UserRoles;

namespace Container_App.Repository.UserRoleRepository
{
    public interface IUserRoleRepository
    {
        Task<int> CreateUserRole(UserRole userRole);
    }
}
