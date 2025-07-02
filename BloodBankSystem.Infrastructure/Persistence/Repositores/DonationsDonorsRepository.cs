using BloodBankSystem.Core.DTOs;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Infrastructure.Persistence.Repositores
{
    public class DonationsDonorsRepository : IDonationsDonorsRepository
    {
        private readonly BloodBankSystemDBContext _context;

        public DonationsDonorsRepository(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public IQueryable<DonationLast30DaysDTO> GetDonationsWithDonorsLast30Days()
        {
            var thirtyDaysAgo = DateTime.Today.AddDays(-30);

            var query = _context.Donations.Include(d => d.Donor)
                                          .Where(d => d.DonationDate >= thirtyDaysAgo)
                                          .Select(d => new DonationLast30DaysDTO
                                          {
                                              Name = d.Donor.FullName,
                                              Email = d.Donor.Email,
                                              DateOfBirth = d.Donor.DateOfBirth.ToString("yyyy-MM-dd"),
                                              Gender = d.Donor.Gender,
                                              Weight = (int)d.Donor.Weight,
                                              BloodType = d.Donor.BloodType,
                                              HRFactor = d.Donor.HRFactor,
                                              DonationDate = d.DonationDate,
                                              QuantityML = d.QuantityML
                                          });

            return query;
        }
    }
}
