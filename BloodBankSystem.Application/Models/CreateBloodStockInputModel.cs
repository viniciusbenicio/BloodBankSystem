using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models;

public class CreateBloodStockInputModel
{
    public string BloodType { get; set; }
    public string HRFactor { get; set; }
    public int QuantityML { get; set; }


    public BloodBankSystem.Core.BloodStock ToEntity()
          => new(BloodType, HRFactor, QuantityML);
}
