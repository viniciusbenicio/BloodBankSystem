using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetAllDonation
{
    public class GetAllDonationHandler : IRequestHandler<GetAllDonationQuery, ResultViewModel<List<DonationViewModel>>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetAllDonationHandler(BloodBankSystemDBContext context, IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetAll();

            var model = donation.Select(DonationViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationViewModel>>.Success(model);
        }
    }
}
