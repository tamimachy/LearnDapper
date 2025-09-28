using Microsoft.Data.SqlClient;
using System.Data;

namespace LearnDapper.Model.Data
{
    public class DapperDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;
        public DapperDBContext(IConfiguration configuration) {
            _configuration = configuration;
            connectionstring = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionstring);
    }
}
