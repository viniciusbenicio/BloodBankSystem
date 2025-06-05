using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.CreateDonation
{
    public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;
        public CreateDonationHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();

            await _donationRepository.Add(donation);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
