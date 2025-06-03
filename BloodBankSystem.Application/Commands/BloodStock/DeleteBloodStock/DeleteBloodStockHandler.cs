using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.BloodStock.DeleteBloodStock
{
    public class DeleteBloodStockHandler : IRequestHandler<DeleteBloodStockCommand, ResultViewModel>
    {
        private readonly BloodBankSystemDBContext _context;
        public DeleteBloodStockHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _context.BloodStocks.SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            if (bloodStocks is null)
            {
                return ResultViewModel.Error("Doador não existe.");
            }

            bloodStocks.SetAsDeleted();
            _context.BloodStocks.Update(bloodStocks);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}
