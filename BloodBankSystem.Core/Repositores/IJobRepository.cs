using BloodBankSystem.Core;

namespace BloodBankSystem.Infrastructure.Core.Repositores
{
    public interface IJobRepository
    {
        List<BloodStock> GetAllBloodStock();
    }
}
