﻿using Container_App.Data;
using Container_App.Model.Users;
using Container_App.utilities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Container_App.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        private readonly Config _config;

        public UserRepository(SqlQueryHelper sqlQueryHelper, Config config)
        {
            _sqlQueryHelper = sqlQueryHelper;
            _config = config;
        }


        public async Task<List<Users>> GetUsers(PagedResult page)
        {
            string sqlQuery = @"
                            SELECT * FROM Users 
                            WHERE (@SearchTerm IS NULL OR FullName LIKE '%' + @SearchTerm + '%') 
                            and IsDel = 0
                            ORDER BY UserId
                            OFFSET @Offset ROWS 
                            FETCH NEXT @PageSize ROWS ONLY";

            // Tạo NpgsqlParameter cho các tham số trong câu truy vấn
            var parameters = new[]
            {
                new NpgsqlParameter("@SearchTerm", page.SearchTerm ?? (object)DBNull.Value),
                new NpgsqlParameter("@Offset", (page.PageNumber - 1) * page.PageSize),
                new NpgsqlParameter("@PageSize", page.PageSize),               
            };

            return await _sqlQueryHelper.ExecuteQueryAsync<Users>(sqlQuery, parameters);
        }

        public async Task<Users> GetUserById(int id)
        {
            string sql = "SELECT * FROM Users WHERE UserId = @UserId";

            // Tạo NpgsqlParameter cho UserId
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", id)
            };

            return await _sqlQueryHelper.ExecuteQuerySingleAsync<Users>(sql, parameters);
        }

        public async Task<int> CreateUser(Users user)
        {
            // Mã hóa mật khẩu người dùng
            user.Password = _config.HashPassword(user.Password);

            // Lấy ID lớn nhất và cộng thêm 1 cho UserId mới
            string sqlGetMaxId = "SELECT COALESCE(MAX(\"UserId\"), 0) + 1 FROM public.\"Users\";";
            user.UserId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            // Câu lệnh INSERT
            string sqlInsert = @"
            INSERT INTO public.""Users"" (""UserId"", ""Username"", ""Password"", ""FullName"", ""IsDel"")
            VALUES(@UserId, @Username, @Password, @FullName, @IsDel);";

            // Tạo NpgsqlParameter cho các tham số trong câu lệnh INSERT
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", user.UserId),
                new NpgsqlParameter("@Username", user.Username),
                new NpgsqlParameter("@Password", user.Password),
                new NpgsqlParameter("@FullName", user.FullName),
                new NpgsqlParameter("@IsDel", user.IsDel)
            };

            // Thực thi câu lệnh INSERT
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);
            return rowsAffected; // Trả về số bản ghi bị ảnh hưởng
        }


        public async Task<int> UpdateUser(Users user)
        {
            string sql = @"
                        UPDATE Users
                        SET Username = @Username, Password = @Password, FullName = @FullName
                        WHERE UserId = @UserId";

            // Tạo SqlParameter cho các tham số trong câu lệnh UPDATE
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", user.UserId),
                new NpgsqlParameter("@Username", user.Username),
                new NpgsqlParameter("@Password", user.Password),
                new NpgsqlParameter("@FullName", user.FullName),              
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

            // Tạo NpgsqlParameter cho UserId
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", id)
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

            // Tạo NpgsqlParameter cho UserId
            var parameters = new[]
            {
                new NpgsqlParameter("@UserId", userId)
            };

            return await _sqlQueryHelper.ExecuteScalarAsync<long>(sql, parameters);
        }


    }
}
