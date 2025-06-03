using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.CreateBloodStock
{
    public class BloodStockHandler : IRequestHandler<CreateBloodStockCommand, ResultViewModel<int>>
    {
        private readonly BloodBankSystemDBContext _context;
        public BloodStockHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStocks = request.ToEntity();

            await _context.BloodStocks.AddAsync(bloodStocks, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel<int>.Success(bloodStocks.Id);
        }
    }
}
