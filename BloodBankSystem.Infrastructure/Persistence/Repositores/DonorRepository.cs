using Azure.Core;
using BloodBankSystem.Core;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BloodBankSystem.Infrastructure.Persistence.Repositores
{
    public class DonorRepository : IDonorRepository
    {
        private readonly BloodBankSystemDBContext _context;
        public DonorRepository(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<Donor> GetById(int id)
        {
            return await _context.Donors
                                 .Include(d => d.Donations)
                                 .Include(d => d.Address)
                                 .FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
        }
        public async Task<List<Donor>> GetAll()
        {
            return await _context.Donors.Include(d => d.Donations)
                                      .Include(d => d.Address)
                                      .Where(d => !d.IsDeleted).ToListAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Donors.AnyAsync(x => x.Id == id);
        }

        public async Task<int> Add(Donor donor)
        {
            await _context.Donors.AddAsync(donor);
            await _context.SaveChangesAsync();

            return donor.Id;
        }
        public async Task Update(Donor donor)
        {
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync();

        }
    }
}
