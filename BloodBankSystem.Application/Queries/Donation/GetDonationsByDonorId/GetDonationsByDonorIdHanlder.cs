using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetDonationsByDonorId
{
    public class GetDonationsByDonorIdHanlder : IRequestHandler<GetDonationsByDonorIdQuery, ResultViewModel<DonationByDonorViewModel>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetDonationsByDonorIdHanlder(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<ResultViewModel<DonationByDonorViewModel>> Handle(GetDonationsByDonorIdQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.DonorId);

            var donationsViewModels = donor.Donations.Select(d => new DonationsViewModel
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
