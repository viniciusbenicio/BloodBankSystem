using System.Reflection;

namespace BloodBankSystem.Core;

public class BloodStock : BaseEntity
{
    public BloodStock(string bloodType, string hRFactor, int quantityML) : base()
    {
        BloodType = bloodType;
        HRFactor = hRFactor;
        QuantityML = quantityML;
    }

    public int Id { get; set; }
    public string BloodType { get; set; }
    public string HRFactor { get; set; }
    public int QuantityML { get; set; }


    public void UpdateBloodStock(string bloodType, string hRFactor, int quantityML)
    {
        if(BloodType == bloodType && HRFactor == hRFactor && quantityML > 0)
        {
            QuantityML += quantityML;

        }

    }
}
