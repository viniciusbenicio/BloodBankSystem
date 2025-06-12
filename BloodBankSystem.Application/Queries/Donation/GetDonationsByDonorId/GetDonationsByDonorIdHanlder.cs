using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetDonationsByDonorId
{
    public class GetDonationsByDonorIdHanlder : IRequestHandler<GetDonationsByDonorIdQuery, ResultViewModel<DonationByDonorViewModel>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;

        public GetDonationsByDonorIdHanlder(IDonationRepository donationRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
        }
        public async Task<ResultViewModel<DonationByDonorViewModel>> Handle(GetDonationsByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.DonorId);
            var donations = await _donationRepository.GetDonationsByDonor(request.DonorId);

            var donationsViewModels = donations.Select(d => new DonationsViewModel
            {
                Id = d.Id,
                QuantityML = d.QuantityML,
                DonationDate = d.DonationDate,
                CreatedAt = d.CreatedAt
            }).ToList();

            var viewModel = new DonationByDonorViewModel(
                donor.FullName,
                donor.Email,
                donor.Gender,
                donor.Weight,
                donor.BloodType,
                donor.HRFactor,
                donationsViewModels
            );

            return ResultViewModel<DonationByDonorViewModel>.Success(viewModel);

        }
    }
}
