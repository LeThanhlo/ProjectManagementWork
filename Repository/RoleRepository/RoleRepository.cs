using Container_App.Model.Permissions;
using Container_App.Model.Roles;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.RoleRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public RoleRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }
        public async Task<int> CreateRole(Role role)
        {
            string sqlGetMaxId = "SELECT COALESCE(MAX(\"RoleId\"), 0) + 1 FROM public.\"Role\";";
            role.RoleId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            string sqlInsert = @"
            INSERT INTO public.""Role"" (""RoleId"", ""RoleName"", ""Description"")
            VALUES(@RoleId, @RoleName, @Description);";

            var parameters = new[]
            {
                new NpgsqlParameter("@RoleId", role.RoleId),
                new NpgsqlParameter("@RoleName", role.RoleName),
                new NpgsqlParameter("@Description", role.Description),              
            };
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected;
        }
    }
}
