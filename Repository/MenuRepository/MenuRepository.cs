using Container_App.Model.Dto;
using Container_App.Model.Menus;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.MenuRepository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public MenuRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }

        public async Task<Menu> GetMenu(string menuname)
        {
            string sql = @"select * from ""Menu"" where ""MenuName"" = @MenuName;";
            var parameters = new[] {new NpgsqlParameter("@MenuName", menuname)};
            var menu = await _sqlQueryHelper.ExecuteQueryAsync<Menu>(sql, parameters);
            return menu.FirstOrDefault();
        }

        public async Task<List<Menu>> GetUserMenus(int userId)
        {
            string sql = @"
                SELECT m.*
                FROM public.""RoleMenuAccess"" rma
                JOIN public.""Menu"" m ON rma.""MenuId"" = m.""MenuId""
                JOIN public.""UserRole"" ur ON rma.""RoleId"" = ur.""RoleId""
                WHERE ur.""UserId"" = @UserId;
            ";

            var parameters = new[] { new NpgsqlParameter("@UserId", userId) };

            return await _sqlQueryHelper.ExecuteQueryAsync<Menu>(sql, parameters);
        }

        public async Task<List<UserPermissionDto>> GetUserPermissions(int userId)
        {
            string sql = @"
                    SELECT 
                        m.""MenuId"", 
                        m.""MenuUrl"", 
                        m.""MenuName"", 
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

            return await _sqlQueryHelper.ExecuteQueryAsync<UserPermissionDto>(sql, parameters);
        }
    }
}
