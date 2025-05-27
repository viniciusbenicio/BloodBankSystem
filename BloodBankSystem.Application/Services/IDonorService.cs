using BloodBankSystem.Application.Models;

namespace BloodBankSystem.Application.Services
{
   
    public interface IDonorService
    {
        ResultViewModel<List<DonorViewModel>> GetAll(string search = "");
        ResultViewModel<DonorViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateDonnorInputModel model);
        ResultViewModel Update(UpdateDonnorInputModel model);
        ResultViewModel Delete(int id);
    }
}
