using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<ResultViewModel>
    {
        public DeleteDonorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
