using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models
{
    public class BloodStockViewModel
    {
        public BloodStockViewModel(string bloodType, string hRFactor, int quantityML)
        {
            BloodType = bloodType;
            HRFactor = hRFactor;
            QuantityML = quantityML;
        }

        public string BloodType { get; set; }
        public string HRFactor { get; set; }
        public int QuantityML { get; set; }

        public static BloodStockViewModel FromEntity(BloodBankSystem.Core.BloodStock entity)
           => new(entity.BloodType, entity.HRFactor, entity.QuantityML);
    }
}
