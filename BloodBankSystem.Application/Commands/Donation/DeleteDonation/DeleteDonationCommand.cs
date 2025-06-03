using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.Donation.DeleteDonation
{
    public class DeleteDonationCommand : IRequest<ResultViewModel<int>>
    {
        public DeleteDonationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
