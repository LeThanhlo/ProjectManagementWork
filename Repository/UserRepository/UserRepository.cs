using Container_App.Data;
using Container_App.Model.Users;
using Container_App.utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Container_App.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;

        public UserRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }


        public async Task<List<UserModel>> GetUsers(PagedResult page)
        {
            string sqlQuery = @"
                            SELECT * FROM Users 
                            WHERE (@SearchTerm IS NULL OR FullName LIKE '%' + @SearchTerm + '%') 
                            and IsDel = 0
                            ORDER BY UserId
                            OFFSET @Offset ROWS 
                            FETCH NEXT @PageSize ROWS ONLY";

            // Tạo SqlParameter cho các tham số trong câu truy vấn
            var parameters = new[]
            {
                new SqlParameter("@SearchTerm", page.SearchTerm ?? (object)DBNull.Value),
                new SqlParameter("@Offset", (page.PageNumber - 1) * page.PageSize),
                new SqlParameter("@PageSize", page.PageSize),               
            };

            return await _sqlQueryHelper.ExecuteQueryAsync<UserModel>(sqlQuery, parameters);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE UserId = @UserId";

            // Tạo SqlParameter cho UserId
            var parameters = new[]
            {
                new SqlParameter("@UserId", id)
            };

            return await _sqlQueryHelper.ExecuteQuerySingleAsync<UserModel>(sql, parameters);
        }

        public async Task<int> CreateUser(UserModel user)
        {
            string sqlGetMaxId = "SELECT ISNULL(MAX(UserId), 0) + 1 FROM Users";
            user.UserId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            string sqlInsert = @"
                            INSERT INTO Users (UserId, Username, Password, FullName, RoleGroupId)
                            VALUES (@UserId, @Username, @Password, @FullName, @RoleGroupId, @IsDel)";

            // Tạo SqlParameter cho các tham số trong câu lệnh INSERT
            var parameters = new[]
            {
                new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@RoleGroupId", user.RoleGroupId),
                new SqlParameter("@IsDel", 0)
            };

            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected; // Trả về số bản ghi bị ảnh hưởng
        }

        public async Task<int> UpdateUser(UserModel user)
        {
            string sql = @"
                        UPDATE Users
                        SET Username = @Username, Password = @Password, FullName = @FullName, RoleGroupId = @RoleGroupId
                        WHERE UserId = @UserId";

            // Tạo SqlParameter cho các tham số trong câu lệnh UPDATE
            var parameters = new[]
            {
                new SqlParameter("@UserId", user.UserId),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Password", user.Password),
                new SqlParameter("@FullName", user.FullName),
                new SqlParameter("@RoleGroupId", user.RoleGroupId)
            };

            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected; // Trả về số bản ghi bị ảnh hưởng
        }

        public async Task<int> DeleteUser(int id)
        {
            string sql = @"
                    UPDATE Users 
                    SET IsDel = 1 
                    WHERE UserId = @UserId";

            // Tạo SqlParameter cho UserId
            var parameters = new[]
            {
                new SqlParameter("@UserId", id)
            };

            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected; // Trả về số bản ghi bị ảnh hưởng
        }


        public async Task<long> CheckAdmin(int userId)
        {
            string sql = @"
                SELECT CASE WHEN EXISTS (
                    SELECT 1 FROM RoleGroups rg
                    JOIN Users u ON rg.RoleGroupId = u.RoleGroupId
                    WHERE u.UserId = @UserId AND rg.RoleGroupName = 'Admin'
                ) THEN 1 ELSE 0 END";

            // Tạo SqlParameter cho UserId
            var parameters = new[]
            {
                new SqlParameter("@UserId", userId)
            };

            return await _sqlQueryHelper.ExecuteScalarAsync<long>(sql, parameters);
        }


    }
}
