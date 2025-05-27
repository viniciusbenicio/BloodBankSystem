namespace BloodBankSystem.Application.Models;

public class UpdateBloodStockInputModel
{
    public int Id { get; set; }
    public string BloodType { get; set; }
    public string HRFactor { get; set; }
    public int QuantityML { get; set; }
}
