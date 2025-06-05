using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.CreateBloodStock
{
    public class BloodStockHandler : IRequestHandler<CreateBloodStockCommand, ResultViewModel<int>>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        public BloodStockHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStocks = request.ToEntity();

            await _bloodStockRepository.Add(bloodStocks);

            return ResultViewModel<int>.Success(bloodStocks.Id);
        }
    }
}
