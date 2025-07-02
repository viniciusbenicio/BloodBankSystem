namespace BloodBankSystem.Core.DTOs
{
    public class DonationLast30DaysDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Weight { get; set; }
        public string BloodType { get; set; }
        public string HRFactor { get; set; }

        public DateTime DonationDate { get; set; }
        public int QuantityML { get; set; }

    }
}
