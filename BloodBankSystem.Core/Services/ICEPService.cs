using BloodBankSystem.Core.DTOs;

namespace BloodBankSystem.Core.Services
{
    public interface ICEPService
    {
        Task<CEPResult> GetByCepAsync(string zipCode);
    }
}
