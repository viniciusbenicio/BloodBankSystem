namespace BloodBankSystem.API.Entities
{
    public class Donation
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityML { get; set; }
        public Donor Donor { get; set; }
    }
}
