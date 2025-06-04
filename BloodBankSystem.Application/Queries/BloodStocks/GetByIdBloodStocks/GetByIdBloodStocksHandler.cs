using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.BloodStocks.GetByIdBloodStocks
{
    public class GetByIdBloodStocksHandler : IRequestHandler<GetByIdBloodStocksQuery, ResultViewModel<BloodStockViewModel>>
    {

        private readonly BloodBankSystemDBContext _context;
        public GetByIdBloodStocksHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<BloodStockViewModel>> Handle(GetByIdBloodStocksQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _context.BloodStocks.FirstOrDefaultAsync(d => d.Id == request.Id && !d.IsDeleted, cancellationToken: cancellationToken);

            if (bloodStock is null)
            {
                return ResultViewModel<BloodStockViewModel>.Error("Não existe estoque de Sangue");
            }

            var model = BloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<BloodStockViewModel>.Success(model);
        }
    }
}
