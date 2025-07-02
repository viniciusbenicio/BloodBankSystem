using BloodBankSystem.Core.DTOs;

namespace BloodBankSystem.Core.Repositores
{
    public interface IDonationsDonorsRepository
    {
        IQueryable<DonationLast30DaysDTO> GetDonationsWithDonorsLast30Days();

    }
}
