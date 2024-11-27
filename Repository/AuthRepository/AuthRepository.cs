using Container_App.Data;
using Container_App.Model.Dto;
using Container_App.Model.Tokens;
using Container_App.Model.Users;
using Container_App.utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;

namespace Container_App.Repository.AuthRepository
{
    public class AuthRepository: IAuthRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        private readonly Config _config;

        public AuthRepository(SqlQueryHelper sqlQueryHelper, Config config)
        {
            _sqlQueryHelper = sqlQueryHelper;
            _config = config;
        }

        public Task<RefreshTokenModel> GetRefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> GetUserByID(int Id)
        {
            string sql = "SELECT * FROM \"Users\" WHERE \"UserId\" = @UserId";

            // Tạo NpgsqlParameter cho UserId
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", Id)
            };

            return await _sqlQueryHelper.ExecuteQuerySingleAsync<Users>(sql, parameters);
        }

        public async Task<Users> GetUserByUsernameAndPassword(string username, string password)
        {
            // Hash mật khẩu trước khi so sánh
            string passwordHash = _config.HashPassword(password);

            // Câu truy vấn SQL
            string sql = @"SELECT * FROM ""Users"" 
                   WHERE ""Username"" = @Username 
                   AND ""Password"" = @Password";

            // Khai báo tham số
            var parameters = new[]
            {
                new NpgsqlParameter("@Username", username),
                new NpgsqlParameter("@Password", passwordHash) // Sử dụng hash của mật khẩu
            };

            // Truy vấn một bản ghi duy nhất
            return await _sqlQueryHelper.ExecuteQuerySingleAsync<Users>(sql, parameters);
        }

        public async Task<List<UserPermission>> GetUserPermissions(int userId)
        {
            string sql = @"SELECT 
                                m.""MenuId"", 
                                p.""CanView"", 
                                p.""CanAdd"", 
                                p.""CanEdit"", 
                                p.""CanDelete"", 
                                p.""TableName""
                            FROM public.""Role"" r
                            JOIN public.""RolePermissions"" rp ON r.""RoleId"" = rp.""RoleId""
                            JOIN public.""Permission"" p ON rp.""PermissionId"" = p.""PermissionId""
                            JOIN public.""UserRole"" ur ON ur.""RoleId"" = r.""RoleId""
                            JOIN public.""Users"" u ON u.""UserId"" = ur.""UserId""
                            JOIN public.""RoleMenuAccess"" rma ON r.""RoleId"" = rma.""RoleId""
                            JOIN public.""Menu"" m ON rma.""MenuId"" = m.""MenuId""
                            WHERE u.""UserId"" = @UserId;
                            ";
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", userId)             
            };
            return await _sqlQueryHelper.ExecuteQueryAsync<UserPermission>(sql, parameters);
        }

        public async Task<bool> HasPermission(int userId, string table, string action)
        {
            var permissions = await GetUserPermissions(userId);

            var menuPermission = permissions.FirstOrDefault(p => p.TableName == table);

            if (menuPermission == null)
            {
                return false; // Nếu không tìm thấy quyền cho menu đó
            }

            switch (action.ToLower())
            {
                case "view":
                    return menuPermission.CanView;
                case "add":
                    return menuPermission.CanAdd;
                case "edit":
                    return menuPermission.CanEdit;
                case "delete":
                    return menuPermission.CanDelete;
                default:
                    return false;
            }
        }

        public Task RevokeRefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task SaveRefreshToken(RefreshTokenModel refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
