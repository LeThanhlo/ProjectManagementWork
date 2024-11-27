using Container_App.Data;
using Container_App.Model.Projects;
using Container_App.Model.Users;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;

        public ProjectRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }
        public async Task<int> AddProjectAsync(Project project, int userId)
        {
            project.Status = (int)StatusProject.Active;
            string sqlGetMaxId = @"SELECT COALESCE(MAX(""ProjectId""), 0) + 1 FROM ""Project"";";
            project.ProjectId = await _sqlQueryHelper.ExecuteScalarAsync<int>(sqlGetMaxId);

            string sqlInsert = @"
            INSERT INTO public.""Project"" (""ProjectId"", ""ProjectName"", ""Description"", ""StartDate"", ""EndDate"", ""Status"",
            ""CreatedBy"", ""CreatedAt"")
            VALUES(@ProjectId, @ProjectName, @Description, @StartDate, @EndDate, @Status, @CreatedBy, @CreatedAt);";

            // Tạo NpgsqlParameter cho các tham số trong câu lệnh INSERT
            var parameters = new[]
            {
                new NpgsqlParameter("@ProjectId", project.ProjectId),
                new NpgsqlParameter("@ProjectName", project.ProjectName),
                new NpgsqlParameter("@Description", project.Description),
                new NpgsqlParameter("@StartDate", project.StartDate),
                new NpgsqlParameter("@EndDate", project.EndDate),
                new NpgsqlParameter("@Status", project.Status),
                new NpgsqlParameter("@CreatedBy", userId),
                new NpgsqlParameter("@CreatedAt", DateTime.Now)              
            };
            // Thực thi câu lệnh INSERT
            return await _sqlQueryHelper.ExecuteNonQueryAsync(sqlInsert, parameters);       
        }

        public async Task<bool> IsLockProjectAsync(int projectId)
        {
            // Câu truy vấn kiểm tra sự tồn tại của dự án và cập nhật trạng thái
            string selectQuery = @"SELECT * FROM public.""Project"" WHERE ""ProjectId"" = @ProjectId";
            string updateQuery = @"UPDATE public.""Project"" 
                           SET ""Status"" = @Status 
                           WHERE ""ProjectId"" = @ProjectId";

            // Tham số cho câu truy vấn
            var selectParameters = new[]
            {
                new NpgsqlParameter("@ProjectId", projectId)
            };

            // Thực hiện truy vấn để kiểm tra xem dự án có tồn tại không
            var project = await _sqlQueryHelper.ExecuteQuerySingleAsync<Project>(selectQuery, selectParameters);

            if (project == null)
            {
                // Nếu không tìm thấy dự án, trả về false
                return false;
            }

            // Tham số cho câu lệnh cập nhật
            var updateParameters = new[]
            {
                new NpgsqlParameter("@Status", (int)StatusProject.Lock),
                new NpgsqlParameter("@ProjectId", projectId)
            };

            // Cập nhật trạng thái của dự án
            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(updateQuery, updateParameters);

            // Kiểm tra xem bản ghi có được cập nhật hay không
            return rowsAffected > 0;
        }
    }
}
