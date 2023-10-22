using Microsoft.Data.SqlClient;
using System.Data;

namespace Shop.Infrastructure.Persistent.Dapper
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public IDbConnection CreateConnection => new SqlConnection(_connectionString);

        public string Inventories => "[seller].Inventories";
        public string OrderItems => "[order].Items";
        public string Products => "[product].Products";
        public string Sellers => "[seller].Sellers";
        public string UserAddresses => "[user].Addresses";
    }
}
