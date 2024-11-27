using Container_App.Model.RoleMenuAccess;
using Container_App.Model.Roles;
using Container_App.utilities;
using Npgsql;
using System.Data;

namespace Container_App.Repository.RoleMenuAccessRepository
{
    public class RoleMenuAccessRepository : IRoleMenuAccessRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public RoleMenuAccessRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }
        public async Task<int> CreateRoleMenuAccess(RoleMenuAcces roleMenuAccess)
        {
            string sqlGetMaxId = "SELECT COALESCE(MAX(\"AccessId\"), 0) + 1 FROM public.\"RoleMenuAccess\";";
            roleMenuAccess.AccessId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            string sqlInsert = @"
            INSERT INTO public.""RoleMenuAccess"" (""AccessId"", ""MenuId"", ""CanAccess"", ""RoleId"")
            VALUES(@AccessId, @MenuId, @CanAccess, @RoleId);";

            var parameters = new[]
            {
                new NpgsqlParameter("@AccessId", roleMenuAccess.AccessId),
                new NpgsqlParameter("@MenuId", roleMenuAccess.MenuId),
                new NpgsqlParameter("@CanAccess", roleMenuAccess.CanAccess),
                new NpgsqlParameter("@RoleId", roleMenuAccess.RoleId)
            };
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected;
        }      
    }
}
