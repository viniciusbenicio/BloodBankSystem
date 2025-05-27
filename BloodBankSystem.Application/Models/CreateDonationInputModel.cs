using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models;

public class CreateDonationInputModel
{
    public int DonationId { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityML { get; set; }
    public Donor Donor { get; set; }
}
