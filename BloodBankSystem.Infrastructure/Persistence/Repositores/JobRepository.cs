using BloodBankSystem.Core;
using BloodBankSystem.Infrastructure.Core.Repositores;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BloodBankSystem.Infrastructure.Persistence.Repositores
{
    public class JobRepository : IJobRepository
    {
        private readonly string _connectionString;
        public JobRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public List<BloodStock> GetAllBloodStock()
        {
            using var connection = new SqlConnection(_connectionString);

            return [.. connection.Query<BloodStock>("SELECT * FROM BloodStocks")];
        }
    }
}
