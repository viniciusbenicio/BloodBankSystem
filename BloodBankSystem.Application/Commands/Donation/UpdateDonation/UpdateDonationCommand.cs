using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.UpdateDonation
{
    public class UpdateDonationCommand : IRequest<ResultViewModel>
    {
        public UpdateDonationCommand(int id, int quantityML)
        {
            Id = id;
            QuantityML = quantityML;
        }

        public int Id { get; set; }
        public int QuantityML { get; set; }
    }
}
