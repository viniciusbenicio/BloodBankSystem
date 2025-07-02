using BloodBankSystem.Core.DTOs;

namespace BloodBankSystem.Core.Repositores
{
    public interface IBloodStockRepository
    {
        Task<List<BloodStock>> GetAll();
        Task<BloodStock> GetById(int id);
        Task<bool> Exists(int id);
        Task<int> Add(BloodStock bloodStock);
        Task Update(BloodStock bloodStock);
        List<BloodStockMinimumDTO> GetBloodStockBelowMinimum(int minQuantity);
    }
}
