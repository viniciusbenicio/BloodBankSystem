using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.DeleteBloodStock
{
    public class DeleteBloodStockHandler : IRequestHandler<DeleteBloodStockCommand, ResultViewModel>
    {
        private readonly IBloodStockRepository _bloodStockRepository;

        public DeleteBloodStockHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _bloodStockRepository.GetById(request.Id);

            if (bloodStocks is null)
            {
                return ResultViewModel.Error("Doador não existe.");
            }

            bloodStocks.SetAsDeleted();
            await _bloodStockRepository.Update(bloodStocks);

            return ResultViewModel.Success();
        }
    }
}
