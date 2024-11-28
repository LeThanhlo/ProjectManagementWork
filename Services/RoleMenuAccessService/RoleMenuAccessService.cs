using Container_App.Model.RoleMenuAccess;
using Container_App.Repository.RoleMenuAccessRepository;

namespace Container_App.Services.RoleMenuAccessService
{
    public class RoleMenuAccessService : IRoleMenuAccessService
    {
        private readonly IRoleMenuAccessRepository _roleMenuAccessRepository;
        public RoleMenuAccessService(IRoleMenuAccessRepository roleMenuAccessRepository)
        {
            _roleMenuAccessRepository = roleMenuAccessRepository;
        }

        public async Task<int> CreateRoleMenuAccess(RoleMenuAcces roleMenuAccess)
        {
            return await _roleMenuAccessRepository.CreateRoleMenuAccess(roleMenuAccess);
        }

        public async Task<int> DeleteRoleMenuAccess(int roleId)
        {
            return await _roleMenuAccessRepository.DeleteRoleMenuAccess(roleId);
        }
    }
}
