using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.Donor.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly BloodBankSystemDBContext _context;
        public UpdateDonorHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _context.Donors.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe");
            }

            donor.Update(request.FullName, request.Email, request.DateOfBirth, request.Gender, request.Weight, request.BloodType, request.HRFactor);
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}
