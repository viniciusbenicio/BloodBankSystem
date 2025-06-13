using BloodBankSystem.Application.Commands.BloodStock.UpdateBloodStock;
using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.BloodStock.UpdateBloodStock
{
    public class UpdateBloodStockHandler : IRequestHandler<UpdateBloodStockCommand, ResultViewModel>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        public UpdateBloodStockHandler(IBloodStockRepository bloodStockRepository)
        {
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var donor = await _bloodStockRepository.GetById(request.Id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe");
            }

            donor.UpdateBloodStock(request.BloodType, request.HRFactor, request.QuantityML);
            await _bloodStockRepository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}
