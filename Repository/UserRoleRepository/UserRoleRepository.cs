using Container_App.Model.Roles;
using Container_App.Model.UserRoles;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.UserRoleRepository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public UserRoleRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }

        public async Task<int> CheckPermissionByUserIdAndTable(int userId, string tableName)
        {
            string sql = @"select ""PermissionId"" from ""UserRole"" ur, ""Permission"" p
                        where p.""PermissionId"" = ur.""RoleId"" and ur.""UserId"" = @UserId and p.""TableName"" = @TableName;";
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", userId),
                new NpgsqlParameter("@TableName", tableName),               
            };
            var permissionId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sql, parameters);
            return permissionId;
        }

        public async Task<int> CreateUserRole(UserRole userRole)
        {
            string sqlGetMaxId = "SELECT COALESCE(MAX(\"Id\"), 0) + 1 FROM public.\"UserRole\";";
            userRole.Id = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            string sqlInsert = @"
            INSERT INTO public.""UserRole"" (""Id"", ""UserId"", ""RoleId"")
            VALUES(@Id, @UserId, @RoleId);"
            ;

            var parameters = new[]
            {
                new NpgsqlParameter("@Id", userRole.Id),
                new NpgsqlParameter("@UserId", userRole.UserId),
                new NpgsqlParameter("@RoleId", userRole.RoleId),
            };
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected;
        }

        public async Task<int> DeleteUserRole(int RoleId)
        {
            string sql = @"delete from ""UserRole"" where ""RoleId"" = @RoleId";
            var parameters = new[]
            {              
                new NpgsqlParameter("@RoleId", RoleId),
            };
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected;
        }
    }
}
