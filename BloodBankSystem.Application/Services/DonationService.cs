using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;

namespace BloodBankSystem.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly BloodBankSystemDBContext _context;
        public DonationService(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<DonationViewModel>> GetAll(string search = "")
        {
            var donation = _context.Donations.Where(d => !d.IsDeleted).ToList();

            var model = donation.Select(DonationViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationViewModel>>.Success(model);
        }

        public ResultViewModel<DonationViewModel> GetById(int id)
        {
            var donation = _context.Donations.FirstOrDefault(d => d.Id == id && !d.IsDeleted);

            if (donation is null)
            {
                return ResultViewModel<DonationViewModel>.Error("Não existe estoque de Sangue");
            }

            var model = DonationViewModel.FromEntity(donation);

            return ResultViewModel<DonationViewModel>.Success(model);
        }
        public ResultViewModel<int> Insert(CreateDonationInputModel model)
        {
            var donation = model.ToEntity();

            _context.Donations.Add(donation);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(donation.Id);
        }

        public ResultViewModel Update(UpdateDonationInputModel model)
        {
            var donation = _context.Donations.FirstOrDefault(d => d.Id == model.Id);

            if (donation is null)
            {
                return ResultViewModel.Error("Não existe Doações.");
            }

            donation.Update(model.QuantityML);
            _context.Donations.Update(donation);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var donation = _context.Donations.SingleOrDefault(d => d.Id == id);

            if (donation is null)
            {
                return ResultViewModel.Error("Não existe Doações.");
            }

            donation.SetAsDeleted();
            _context.Donations.Update(donation);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }


    }
}
