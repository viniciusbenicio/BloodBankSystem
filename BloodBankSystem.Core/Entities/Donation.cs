namespace BloodBankSystem.Core;

public class Donation
{
    public int Id { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityML { get; set; }
    public int DonorId { get; set; }
    public Donor Donor { get; set; }
}
