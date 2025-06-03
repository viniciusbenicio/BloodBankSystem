using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.CreateBloodStock
{
    public class CreateBloodStockCommand : IRequest<ResultViewModel<int>>
    {
        public CreateBloodStockCommand(string bloodType, string hRFactor, int quantityML)
        {
            BloodType = bloodType;
            HRFactor = hRFactor;
            QuantityML = quantityML;
        }

        public string BloodType { get; set; }
        public string HRFactor { get; set; }
        public int QuantityML { get; set; }

        public BloodBankSystem.Core.BloodStock ToEntity()
            => new(BloodType, HRFactor, QuantityML);

    }
}
