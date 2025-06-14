namespace BloodBankSystem.Core.Repositores
{
    public interface IDonationRepository
    {
        Task<List<Donation>> GetAll();
        Task<Donation> GetById(int id);
        Task<bool> Exists(int id);
        Task<int> Add(Donation donation);
        Task Update(Donation donation);
        //Task<List<Donation>> GetDonationsByDonor(int donorId);
    }
}
