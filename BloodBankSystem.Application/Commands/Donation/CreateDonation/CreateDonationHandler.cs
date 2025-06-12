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
            var donations = await _donationRepository.GetAll();

            var lastDonations = donations.LastOrDefault(x => x.DonorId == request.DonorId);

            bool isDonationNotAllowed = donor.IsEligibleForRegistrationOnly(donor.DateOfBirth);
            bool isWeightNotAllowed = donor.CalculateWeight(donor.Weight);
            bool isBelowMinimumDonationAmount = donor.isBelowMinimumDonationAmount(request.QuantityML);
            var isDonationAllowedGender = donor.isCanDonateGender(lastDonations?.DonationDate, donor.Gender);

            if (!isDonationNotAllowed)
                return ResultViewModel<int>.Error($"O Doador é menor de idade então não pode realizar doação");
            if (!isWeightNotAllowed)
                return ResultViewModel<int>.Error($"O Doador não tem peso minímo para realizar doação");
            if (!isBelowMinimumDonationAmount)
                return ResultViewModel<int>.Error($"Qantidade de mililitros de sangue doados deve ser entre 420ml e 470ml");
            if(!isDonationAllowedGender && donor.Gender.Equals("Masculino"))
                return ResultViewModel<int>.Error($"Homens só podem doar de 60 em 60 dias");
            if (!isDonationAllowedGender && donor.Gender.Equals("Feminino"))
                return ResultViewModel<int>.Error($"Mulheres só podem doar de 90 em 90 dias");



            await _donationRepository.Add(donation);

            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
