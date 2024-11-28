using Container_App.Model.UserRoles;

namespace Container_App.Services.UserRoleService
{
    public interface IUserRoleService
    {
        Task<int> CreateUserRole(UserRole userRole);
        Task<int> CheckPermissionByUserIdAndTable(int userId, string tableName);
        Task<int> DeleteUserRole(int RoleId);
    }
}
