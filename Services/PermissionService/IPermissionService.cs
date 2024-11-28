using Container_App.Model.Permissions;

namespace Container_App.Services.PermissionService
{
    public interface IPermissionService
    {
        Task<List<string>> GetListTableName();

        Task<int> CreatePermission(Permission permission);
        Task<int> DeletePermission(int permissionId);
    }
}
