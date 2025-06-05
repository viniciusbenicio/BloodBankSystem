using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetAllDonation
{
    public class GetAllBloodStocksHandler : IRequestHandler<GetAllBloodStocksQuery, ResultViewModel<List<BloodStockViewModel>>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        public GetAllBloodStocksHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<ResultViewModel<List<BloodStockViewModel>>> Handle(GetAllBloodStocksQuery request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _bloodStockRepository.GetAll();

            var model = bloodStocks.Select(BloodStockViewModel.FromEntity).ToList();

            return ResultViewModel<List<BloodStockViewModel>>.Success(model);
        }
    }
}
