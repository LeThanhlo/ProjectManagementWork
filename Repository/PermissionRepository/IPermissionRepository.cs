using Container_App.Model.Permissions;

namespace Container_App.Repository.PermissionRepository
{
    public interface IPermissionRepository
    {
        Task<List<string>> GetListTableName();

        Task<int> CreatePermission(Permission permission);

        Task<int> DeletePermission(int permissionId);
    }
}
