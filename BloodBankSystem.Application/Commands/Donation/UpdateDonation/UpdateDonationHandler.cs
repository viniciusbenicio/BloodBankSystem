using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.UpdateDonation
{
    public class UpdateDonationHandler : IRequestHandler<UpdateDonationCommand, ResultViewModel>
    {
        private readonly IDonationRepository _donationRepository;
        public UpdateDonationHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }
        public async Task<ResultViewModel> Handle(UpdateDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetById(request.Id);

            if (donation is null)
            {
                return ResultViewModel.Error("Não existe Doações.");
            }

            donation.Update(request.QuantityML);
            await _donationRepository.Update(donation);

            return ResultViewModel.Success();
        }
    }
}
