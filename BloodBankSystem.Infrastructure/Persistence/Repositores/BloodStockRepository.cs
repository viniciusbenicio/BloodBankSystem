using BloodBankSystem.Core;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Infrastructure.Persistence.Repositores
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankSystemDBContext _context;
        public BloodStockRepository(BloodBankSystemDBContext context)
        {
            _context = context;
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
            await _context.SaveChangesAsync();

            return bloodStock.Id;
        }
        public async Task Update(BloodStock bloodStock)
        {
            _context.BloodStocks.Update(bloodStock);
            await _context.SaveChangesAsync();

        }
    }
}
