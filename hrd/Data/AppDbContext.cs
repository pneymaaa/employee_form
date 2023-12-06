using System.Data;
using Microsoft.Data.SqlClient;

namespace hrd.Data
{
    public class AppDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbConnectionString");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}