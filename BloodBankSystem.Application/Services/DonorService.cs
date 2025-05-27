using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly BloodBankSystemDBContext _context;
        public DonorService(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<DonorViewModel>> GetAll(string search = "")
        {
            var donor = _context.Donors.Include(d => d.Donations)
                                       .Include(d => d.Address)
                                       .Where(d => !d.IsDeleted).ToList();

            var model = donor.Select(DonorViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorViewModel>>.Success(model);
        }

        public ResultViewModel<DonorViewModel> GetById(int id)
        {
            var donor = _context.Donors
                .Include(d => d.Donations)
                .Include(d => d.Address)
                .FirstOrDefault(d => d.Id == id && !d.IsDeleted);

            if (donor is null)
            {
                return ResultViewModel<DonorViewModel>.Error("Doador não existe.");
            }

            var model = DonorViewModel.FromEntity(donor);

            return ResultViewModel<DonorViewModel>.Success(model);
        }
        public ResultViewModel<int> Insert(CreateDonnorInputModel model)
        {
            var donor = model.ToEntity();

            _context.Donors.Add(donor);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(donor.Id);
        }

        public ResultViewModel Update(UpdateDonnorInputModel model)
        {
            var donor = _context.Donors.FirstOrDefault(d => d.Id == model.Id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe");
            }

            donor.Update(model.FullName, model.Email, model.DateOfBirth, model.Gender, model.Weight, model.BloodType, model.HRFactor);
            _context.Donors.Update(donor);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
        public ResultViewModel Delete(int id)
        {
            var donor = _context.Donors.SingleOrDefault(d => d.Id == id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe.");
            }

            donor.SetAsDeleted();
            _context.Donors.Update(donor);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

       
    }
}
