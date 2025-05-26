using BloodBankSystem.API.Entities;

namespace BloodBankSystem.API.Models
{
    public class CreateDonnorInputModel
    {
        public int DonationId { get; set; }
        public DateTime DonationDate { get; set; }
        public int QuantityML { get; set; }
        public Donor Donor { get; set; }
    }
}
