namespace BloodBankSystem.Application.Models;

public class UpdateBloodStockInputModel
{
    public string BloodType { get; set; }
    public string HRFactor { get; set; }
    public int QuantityML { get; set; }
}
