using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.CreateDonation
{
    public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly BloodBankSystemDBContext _context;
        public CreateDonationHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();

            await _context.Donations.AddAsync(donation, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
