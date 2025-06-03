using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.DeleteBloodStock
{
    public class DeleteBloodStockCommand : IRequest<ResultViewModel>
    {
        public DeleteBloodStockCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
