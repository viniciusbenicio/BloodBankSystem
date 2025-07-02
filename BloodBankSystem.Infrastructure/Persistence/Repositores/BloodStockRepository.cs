using BloodBankSystem.Core;
using BloodBankSystem.Core.DTOs;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq;

namespace BloodBankSystem.Infrastructure.Persistence.Repositores
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankSystemDBContext _context;
        private readonly string _connectionString;

        public BloodStockRepository(BloodBankSystemDBContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<BloodStock> GetById(int id)
        {
            return await _context.BloodStocks.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<BloodStock>> GetAll()
        {
            return await _context.BloodStocks.ToListAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.BloodStocks.AnyAsync(x => x.Id == id);
        }

        public async Task<int> Add(BloodStock bloodStock)
        {
            await _context.BloodStocks.AddAsync(bloodStock);

            return bloodStock.Id;
        }
        public async Task Update(BloodStock bloodStock)
        {
            _context.BloodStocks.Update(bloodStock);
            await _context.SaveChangesAsync();

        }

        public List<BloodStockMinimumDTO> GetBloodStockBelowMinimum(int minQuantity)
        {
            using var connection = new SqlConnection(_connectionString);

            var parametros = new
            {
                minQuantity
            };

            return connection.Query<BloodStockMinimumDTO>("GetBloodStockBelowMinimum", param: parametros, commandType: CommandType.StoredProcedure).ToList();

        }

        public IQueryable<BloodStockByTypeDTO> GetTotalBloodStockByType()
        {
            var bloodStocks = _context.BloodStocks.Where(x => !x.IsDeleted)
                                                  .GroupBy(x => new { x.BloodType, x.HRFactor })
                                                  .Select(g => new BloodStockByTypeDTO
                                                  {
                                                      BloodType = g.Key.BloodType,
                                                      HRFactor = g.Key.HRFactor,
                                                      QuantityMl = g.Sum(x => x.QuantityML)
                                                  });

            return bloodStocks;
        }

    }
}
