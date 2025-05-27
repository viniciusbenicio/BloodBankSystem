using BloodBankSystem.Application.Models;

namespace BloodBankSystem.Application.Services
{
   
    public interface IDonationService
    {
        ResultViewModel<List<DonationViewModel>> GetAll(string search = "");
        ResultViewModel<DonationViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateDonationInputModel model);
        ResultViewModel Update(UpdateDonationInputModel model);
        ResultViewModel Delete(int id);
    }
}
