using BloodBankSystem.Application.Commands.Donation.CreateDonation;
using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.Donation.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {

        private readonly BloodBankSystemDBContext _context;
        public DeleteDonationHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            if (donation is null)
            {
                return ResultViewModel.Error("Não existe Doações.");
            }

            donation.SetAsDeleted();
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}
