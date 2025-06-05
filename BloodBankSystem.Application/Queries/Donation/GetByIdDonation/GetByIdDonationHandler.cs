using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetByIdDonation
{
    public class GetByIdDonationHandler : IRequestHandler<GetByIdDonationQuery, ResultViewModel<DonationViewModel>>
    {
        private readonly IDonationRepository _donationRepository;

        public GetByIdDonationHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<DonationViewModel>> Handle(GetByIdDonationQuery request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetById(request.Id);

            if (donation is null)
            {
                return ResultViewModel<DonationViewModel>.Error("Não existe estoque de Sangue");
            }

            var model = DonationViewModel.FromEntity(donation);

            return ResultViewModel<DonationViewModel>.Success(model);
        }
    }
}
