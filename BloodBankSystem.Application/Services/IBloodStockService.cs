using BloodBankSystem.Application.Models;

namespace BloodBankSystem.Application.Services
{
   
    public interface IBloodStockService
    {
        ResultViewModel<List<BloodStockViewModel>> GetAll(string search = "");
        ResultViewModel<BloodStockViewModel> GetById(int id);
        ResultViewModel<int> Insert(CreateBloodStockInputModel model);
        ResultViewModel Update(UpdateBloodStockInputModel model);
        ResultViewModel Delete(int id);
    }
}
