using Container_App.Model.Roles;
using Container_App.Repository.RoleRepository;

namespace Container_App.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<int> CreateRole(Role role)
        {
            return await _roleRepository.CreateRole(role);
        }

        public async Task<int> DeleteRole(int RoleId)
        {
            return await _roleRepository.DeleteRole(RoleId);
        }
    }
}
