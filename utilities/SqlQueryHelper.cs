using Container_App.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Container_App.utilities
{
    public class SqlQueryHelper
    {
        private readonly MyDbContext _context;
        public SqlQueryHelper(MyDbContext context)
        {
            _context = context;
        }

        // Method to execute a query and return a list of results
        public async Task<List<T>> ExecuteQueryAsync<T>(string sql, params object[] parameters) where T : class
        {
            return await _context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
        }

        // Method to execute a query and return a single result
        public async Task<T> ExecuteQuerySingleAsync<T>(string sql, params object[] parameters) where T : class
        {
            return await _context.Set<T>().FromSqlRaw(sql, parameters).FirstOrDefaultAsync();
        }

        // Method to execute a non-query command (INSERT, UPDATE, DELETE)
        public async Task<int> ExecuteNonQueryAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }
        public async Task<T> ExecuteScalarAsync<T>(string sql, params object[] parameters)
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = sql;

            if (parameters != null)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    var parameter = command.CreateParameter();
                    parameter.ParameterName = $"@p{i}";
                    parameter.Value = parameters[i] ?? DBNull.Value;
                    command.Parameters.Add(parameter);
                }
            }

            if (command.Connection.State != ConnectionState.Open)
            {
                await command.Connection.OpenAsync();
            }

            var result = await command.ExecuteScalarAsync();
            return (T)result; // Đảm bảo trả về đúng kiểu
        }
    }
}
