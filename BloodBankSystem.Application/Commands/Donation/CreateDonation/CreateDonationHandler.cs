using BloodBankSystem.Application.Models;
using BloodBankSystem.Core;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Persistence.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.CreateDonation
{
    public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodStockRepository _bloodStockRepository;
        public CreateDonationHandler(IDonationRepository donationRepository, IDonorRepository donorRepository, IBloodStockRepository bloodStockRepository)
        {
            _donationRepository = donationRepository;
            _donorRepository = donorRepository;
            _bloodStockRepository = bloodStockRepository;
        }
        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = request.ToEntity();

            var donor = await _donorRepository.GetById(request.DonorId);
            var donations = await _donationRepository.GetAll();
            var lastDonations = donations.LastOrDefault(x => x.DonorId == request.DonorId);
            var bloodStocks = await _bloodStockRepository.GetAll();

            bool isDonationNotAllowed = donor.IsEligibleForRegistrationOnly(donor.DateOfBirth);
            bool isWeightNotAllowed = donor.CalculateWeight(donor.Weight);
            bool isBelowMinimumDonationAmount = donor.isBelowMinimumDonationAmount(request.QuantityML);
            bool isDonationAllowedGender = donor.isCanDonateGender(lastDonations?.DonationDate, donor.Gender);

            if (!isDonationNotAllowed)
                return ResultViewModel<int>.Error($"O Doador é menor de idade então não pode realizar doação");
            if (!isWeightNotAllowed)
                return ResultViewModel<int>.Error($"O Doador não tem peso minímo para realizar doação");
            if (!isBelowMinimumDonationAmount)
                return ResultViewModel<int>.Error($"Qantidade de mililitros de sangue doados deve ser entre 420ml e 470ml");
            if (!isDonationAllowedGender && donor.Gender.Equals("Masculino"))
                return ResultViewModel<int>.Error($"Homens só podem doar de 60 em 60 dias");
            if (!isDonationAllowedGender && donor.Gender.Equals("Feminino"))
                return ResultViewModel<int>.Error($"Mulheres só podem doar de 90 em 90 dias");

            await _donationRepository.Add(donation);

            foreach (var bloodStock  in bloodStocks)
            {
                bloodStock.UpdateBloodStock(donor.BloodType, donor.HRFactor, donation.QuantityML);
                await _bloodStockRepository.Update(bloodStock);
            }


            return ResultViewModel<int>.Success(donation.Id);
        }
    }
}
