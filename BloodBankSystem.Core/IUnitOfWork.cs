using BloodBankSystem.Core.Repositores;

namespace BloodBankSystem.Core
{
    public interface IUnitOfWork
    {
        IDonorRepository Donors { get; }
        IDonationRepository Donations { get; }
        IBloodStockRepository BloodStocks { get; }
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
    }
}
