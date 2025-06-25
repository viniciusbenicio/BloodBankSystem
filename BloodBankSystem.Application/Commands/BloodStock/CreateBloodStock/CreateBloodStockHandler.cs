using BloodBankSystem.Application.Models;
using BloodBankSystem.Core;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.CreateBloodStock
{
    public class CreateBloodStockHandler : IRequestHandler<CreateBloodStockCommand, ResultViewModel<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBloodStockHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStocks = request.ToEntity();

            await _unitOfWork.BeginTransactionAsync();
            await _unitOfWork.BloodStocks.Add(bloodStocks);
            await _unitOfWork.CompleteAsync();
            await _unitOfWork.CommitAsync();

            return ResultViewModel<int>.Success(bloodStocks.Id);
        }
    }
}
