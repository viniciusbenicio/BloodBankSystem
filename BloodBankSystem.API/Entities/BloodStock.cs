namespace BloodBankSystem.API.Entities
{
    public class BloodStock
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public string HRFactor { get; set; }
        public int QuantityML { get; set; }
    }
}
