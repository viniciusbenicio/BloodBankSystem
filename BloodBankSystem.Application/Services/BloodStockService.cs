using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;

namespace BloodBankSystem.Application.Services
{
    public class BloodStockService : IBloodStockService
    {
        private readonly BloodBankSystemDBContext _context;
        public BloodStockService(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<BloodStockViewModel>> GetAll(string search = "")
        {
            var bloodStocks = _context.BloodStocks.Where(d => !d.IsDeleted).ToList();

            var model = bloodStocks.Select(BloodStockViewModel.FromEntity).ToList();

            return ResultViewModel<List<BloodStockViewModel>>.Success(model);
        }

        public ResultViewModel<BloodStockViewModel> GetById(int id)
        {
            var bloodStock = _context.BloodStocks.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

            if (bloodStock is null)
            {
                return ResultViewModel<BloodStockViewModel>.Error("Não existe estoque de Sangue");
            }

            var model = BloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<BloodStockViewModel>.Success(model);
        }
        public ResultViewModel<int> Insert(CreateBloodStockInputModel model)
        {
            var bloodStocks = model.ToEntity();

            _context.BloodStocks.Add(bloodStocks);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(bloodStocks.Id);
        }

        public ResultViewModel Update(UpdateBloodStockInputModel model)
        {
            var bloodStocks = _context.BloodStocks.FirstOrDefault(d => d.Id == model.Id);

            if (bloodStocks is null)
            {
                return ResultViewModel.Error("Não existe Estoque de Sangue");
            }

            bloodStocks.Update(model.BloodType, model.HRFactor, model.QuantityML);
            _context.BloodStocks.Update(bloodStocks);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var bloodStocks = _context.BloodStocks.SingleOrDefault(d => d.Id == id);

            if (bloodStocks is null)
            {
                return ResultViewModel.Error("Doador não existe.");
            }

            bloodStocks.SetAsDeleted();
            _context.BloodStocks.Update(bloodStocks);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }


    }
}
