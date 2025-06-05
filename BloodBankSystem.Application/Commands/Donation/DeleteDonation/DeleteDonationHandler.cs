using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.DeleteDonation
{
    public class DeleteDonationHandler : IRequestHandler<DeleteDonationCommand, ResultViewModel>
    {

       private readonly IDonationRepository _donationRepository;
        public DeleteDonationHandler(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel> Handle(DeleteDonationCommand request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepository.GetById(request.Id);

            if (donation is null)
            {
                return ResultViewModel.Error("Não existe Doações.");
            }

            donation.SetAsDeleted();
            await _donationRepository.Update(donation);

            return ResultViewModel.Success();
        }
    }
}
