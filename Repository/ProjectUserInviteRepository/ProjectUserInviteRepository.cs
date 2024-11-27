using Container_App.Data;
using Container_App.Model.ProjectUserInvites;
using Container_App.Model.Users;
using Container_App.utilities;
using Npgsql;

namespace Container_App.Repository.ProjectUserInviteRepository
{
    public class ProjectUserInviteRepository : IProjectUserInviteRepository
    {
        private readonly SqlQueryHelper _sqlQueryHelper;
        public ProjectUserInviteRepository(SqlQueryHelper sqlQueryHelper)
        {
            _sqlQueryHelper = sqlQueryHelper;
        }
        public async Task<int> AcceptInviteAsync(ProjectUserInvite invite)
        {           
            string sql = @"update public.""ProjectUserInvite"" set ""Status"" = @Status, ""AcceptedAt"" = @AcceptedAt";
            var parameters = new[]
             {
                new NpgsqlParameter("@Status", 1),
                new NpgsqlParameter("@AcceptedAt", DateTime.Now)             
            };

            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected;
        }

        public async Task<int> DeclineInviteAsync(ProjectUserInvite invite)
        {
            string sql = @"update public.""ProjectUserInvite"" set ""Status"" = @Status, ""AcceptedAt"" = @AcceptedAt";
            var parameters = new[]
             {
                new NpgsqlParameter("@Status", 2),
                new NpgsqlParameter("@AcceptedAt", DateTime.Now)
            };

            int rowsAffected = await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters);
            return rowsAffected;
        }

        public async Task<ProjectUserInvite> GetInviteAsync(int inviteId)
        {
            string sql = "SELECT * FROM \"ProjectUserInvite\" WHERE \"InviteId\" = @InviteId";

            // Tạo NpgsqlParameter cho UserId
            var parameters = new[]
            {
                new NpgsqlParameter("@InviteId", inviteId)
            };

            return await _sqlQueryHelper.ExecuteQuerySingleAsync<ProjectUserInvite>(sql, parameters);
        }

        public async Task<int> SendInvitesAsync(int projectId, List<int> userIds)
        {
            // Chuẩn bị danh sách các tham số cho câu lệnh INSERT
            var sentAt = DateTime.Now;
            var values = new List<string>();
            var parameters = new List<NpgsqlParameter>();

            // Duyệt qua các UserId và tạo các giá trị INSERT
            for (int i = 0; i < userIds.Count; i++)
            {
                values.Add($"(@ProjectId, @UserId{i}, 0, @SentAt{i})");
                parameters.Add(new NpgsqlParameter($"@UserId{i}", userIds[i]));
                parameters.Add(new NpgsqlParameter($"@SentAt{i}", sentAt));
            }

            // Câu lệnh SQL INSERT
            string sql = $@"
                INSERT INTO ""ProjectUserInvite"" (""ProjectId"", ""UserId"", ""Status"", ""SentAt"")
                VALUES {string.Join(", ", values)}";

            // Thêm tham số cho ProjectId và SentAt
            parameters.Add(new NpgsqlParameter("@ProjectId", projectId));
            parameters.Add(new NpgsqlParameter("@SentAt", sentAt));

            // Thực thi câu lệnh SQL
            return await _sqlQueryHelper.ExecuteNonQueryAsync(sql, parameters.ToArray());
        }

    }
}
