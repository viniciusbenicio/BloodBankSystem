namespace BloodBankSystem.Application.Models;

public class CreateBloodStockInputModel
{
    public string BloodType { get; set; }
    public string HRFactor { get; set; }
    public int QuantityML { get; set; }
}
