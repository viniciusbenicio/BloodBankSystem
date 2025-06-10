using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.CreateDonation
{
    public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        public CreateDonationHandler(IDonationRepository donationRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
        }
        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();

            var donor = await _donorRepository.GetById(request.DonorId);

            bool isDonationNotAllowed = donor.IsEligibleForRegistrationOnly(donor.DateOfBirth);
            bool isWeightNotAllowed = donor.CalculateWeight(donor.Weight);
            bool isBelowMinimumDonationAmount = donor.isBelowMinimumDonationAmount(request.QuantityML);

            if (!isDonationNotAllowed)
                return ResultViewModel<int>.Error($"O Doador é menor de idade então não pode realizar doação");
            if(!isWeightNotAllowed)
                return ResultViewModel<int>.Error($"O Doador não tem peso minímo para realizar doação");
            if(!isBelowMinimumDonationAmount)
                return ResultViewModel<int>.Error($"Qantidade de mililitros de sangue doados deve ser entre 420ml e 470ml");


            await _donationRepository.Add(donation);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
