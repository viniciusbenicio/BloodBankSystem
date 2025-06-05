using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Queries.BloodStocks.GetByIdBloodStocks
{
    public class GetByIdBloodStocksHandler : IRequestHandler<GetByIdBloodStocksQuery, ResultViewModel<BloodStockViewModel>>
    {

        private readonly IBloodStockRepository _bloodStockRepository;

        public GetByIdBloodStocksHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<ResultViewModel<BloodStockViewModel>> Handle(GetByIdBloodStocksQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _bloodStockRepository.GetById(request.Id);

            if (bloodStock is null)
            {
                return ResultViewModel<BloodStockViewModel>.Error("Não existe estoque de Sangue");
            }

            var model = BloodStockViewModel.FromEntity(bloodStock);

            return ResultViewModel<BloodStockViewModel>.Success(model);
        }
    }
}
