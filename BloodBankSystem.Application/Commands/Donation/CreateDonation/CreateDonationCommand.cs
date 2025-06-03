using BloodBankSystem.Application.Models;
using BloodBankSystem.Core;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donation.CreateDonation
{
    public class CreateDonationCommand : IRequest<ResultViewModel<int>>
    {
        public int DonorId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityML { get; set; }
        public BloodBankSystem.Core.Donation ToEntity()
             => new(DonorId, DonationDate, QuantityML);
    }
}
