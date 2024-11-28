using Container_App.Model.RolePermissions;
using Container_App.Model.Roles;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.RolePermissionsRepository
{
    public class RolePermissionsRepository : IRolePermissionsRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public RolePermissionsRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }
        public async Task<int> CreateRolePermission(RolePermission permission)
        {
            string sqlGetMaxId = "SELECT COALESCE(MAX(\"Id\"), 0) + 1 FROM public.\"RolePermissions\";";
            permission.Id = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            string sqlInsert = @"
            INSERT INTO public.""RolePermissions"" (""Id"", ""RoleId"", ""PermissionId"")
            VALUES(@Id, @RoleId, @PermissionId);";

            var parameters = new[]
            {
                new NpgsqlParameter("@Id", permission.Id),
                new NpgsqlParameter("@RoleId", permission.RoleId),
                new NpgsqlParameter("@PermissionId", permission.PermissionId),
            };
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected;
        }

        public async Task<int> DeleteRolePermission(int roleId)
        {
            string sql = @"delete from ""RolePermissions"" where ""RoleId"" = @RoleId";
            var parameters = new[]
            {
                new NpgsqlParameter("@RoleId", roleId),
            };
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected;
        }
    }
}
