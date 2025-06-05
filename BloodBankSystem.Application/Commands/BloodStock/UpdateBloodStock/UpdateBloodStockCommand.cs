using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.BloodStock.UpdateBloodStock
{
    public class UpdateBloodStockCommand : IRequest<ResultViewModel>
    {
        public UpdateBloodStockCommand(string bloodType, string hRFactor, int quantityML)
        {
            BloodType = bloodType;
            HRFactor = hRFactor;
            QuantityML = quantityML;
        }

        public int Id { get; set; }
        public string BloodType { get; set; }
        public string HRFactor { get; set; }
        public int QuantityML { get; set; }
    }
}
