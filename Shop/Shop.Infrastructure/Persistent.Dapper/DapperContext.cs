using Microsoft.Data.SqlClient;
using System.Data;

namespace Shop.Infrastructure.Persistent.Dapper
{
    internal class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);

        public string Inventories => "[seller].Inventories";
    }
}
