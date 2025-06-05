using BloodBankSystem.Core;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Infrastructure.Persistence.Repositores
{
    public class DonationRepository : IDonationRepository
    {
        private readonly BloodBankSystemDBContext _context;
        public DonationRepository(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<Donation> GetById(int id)
        {
            return await _context.Donations.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Donation>> GetAll()
        {
            return await _context.Donations.ToListAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await _context.Donations.AnyAsync(x => x.Id == id);
        }

        public async Task<int> Add(Donation donation)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();

            return donation.Id;
        }
        public async Task Update(Donation donation)
        {
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();

        }
    }
}
