using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.Donation.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly BloodBankSystemDBContext _context;
        public UpdateDonationHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            if (donation is null)
            {
                return ResultViewModel.Error("Não existe Doações.");
            }

            donation.Update(request.QuantityML);
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}
