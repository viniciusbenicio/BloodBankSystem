namespace BloodBankSystem.Core.DTOs
{
    public class BloodStockMinimumDTO
    {
        public int Id { get; set; }
        public string BloodType { get; set; } = string.Empty;
        public string HRFactor { get; set; } = string.Empty;
        public int QuantityML { get; set; } 
    }
}
