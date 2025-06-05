namespace BloodBankSystem.Core.Repositores
{
    public interface IDonorRepository
    {
        Task<List<Donor>> GetAll();
        Task<Donor> GetById(int id);
        Task<bool> Exists(int id);
        Task<int> Add(Donor donor);
        Task Update(Donor donor);
    }
}
