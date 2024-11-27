using Container_App.Model.Permissions;
using Container_App.Repository.PermissionRepository;

namespace Container_App.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task<int> CreatePermission(Permission permission)
        {
            return await _permissionRepository.CreatePermission(permission);
        }

        public async Task<List<string>> GetListTableName()
        {
            return await _permissionRepository.GetListTableName();
        }
    }
}
