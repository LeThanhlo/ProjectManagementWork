using Container_App.Model.UserRoles;
using Container_App.Repository.UserRoleRepository;

namespace Container_App.Services.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        public UserRoleService(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CheckPermissionByUserIdAndTable(int userId, string tableName)
        {
            return await _repository.CheckPermissionByUserIdAndTable(userId, tableName);
        }

        public async Task<int> CreateUserRole(UserRole userRole)
        {
            return await _repository.CreateUserRole(userRole);
        }

        public async Task<int> DeleteUserRole(int RoleId)
        {
            return await _repository.DeleteUserRole(RoleId);
        }
    }
}
