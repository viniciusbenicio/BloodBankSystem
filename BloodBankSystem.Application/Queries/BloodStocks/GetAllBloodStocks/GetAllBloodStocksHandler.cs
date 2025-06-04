using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donation.GetAllDonation
{
    public class GetAllBloodStocksHandler : IRequestHandler<GetAllBloodStocksQuery, ResultViewModel<List<BloodStockViewModel>>>
    {
        private readonly BloodBankSystemDBContext _context;
        public GetAllBloodStocksHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<BloodStockViewModel>>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _context.BloodStocks.Where(d => !d.IsDeleted).ToListAsync(cancellationToken: cancellationToken);

            var model = bloodStocks.Select(BloodStockViewModel.FromEntity).ToList();

            return ResultViewModel<List<BloodStockViewModel>>.Success(model);
        }
    }
}
