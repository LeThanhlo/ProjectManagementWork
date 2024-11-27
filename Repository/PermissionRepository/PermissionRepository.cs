using Container_App.Model.Permissions;
using Container_App.Model.Users;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.PermissionRepository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public PermissionRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }
        public async Task<int> CreatePermission(Permission permission)
        {
            string sqlGetMaxId = "SELECT COALESCE(MAX(\"PermissionId\"), 0) + 1 FROM public.\"Permission\";";
            permission.PermissionId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);
            
            string sqlInsert = @"
            INSERT INTO public.""Users"" (""PermissionId"", ""TableName"", ""CanView"", ""CanAdd"", ""CanEdit"", ""CanDelete"")
            VALUES(@PermissionId, @TableName, @CanView, @CanAdd, @CanEdit, @CanDelete);";
          
            var parameters = new[]
            {
                new NpgsqlParameter("@PermissionId", permission.PermissionId),
                new NpgsqlParameter("@TableName", permission.TableName),
                new NpgsqlParameter("@CanView", permission.CanView),
                new NpgsqlParameter("@CanAdd", permission.CanAdd),
                new NpgsqlParameter("@CanEdit", permission.CanEdit),
                new NpgsqlParameter("@CanDelete", permission.CanDelete)
            };
        
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected;
        }

        public async Task<List<string>> GetListTableName()
        {
            string sql = "SELECT DISTINCT \"TableName\"\r\nFROM \"Permission\";";

            return await _sqlQueryHelper.ExecuteQueryAsync<string>(sql);
        }
    }
}
