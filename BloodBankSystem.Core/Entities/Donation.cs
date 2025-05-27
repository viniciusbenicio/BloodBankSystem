namespace BloodBankSystem.Core;

public class Donation : BaseEntity
{
    public Donation(int donorId,DateTime donationDate, int quantityML) : base()
    {
        DonorId = donorId;
        DonationDate = donationDate;
        QuantityML = quantityML;
    }

    public int Id { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityML { get; set; }
    public int DonorId { get; set; }
    public Donor Donor { get; set; }

    public void Update(int quantityML)
    {
        QuantityML = quantityML;
    }
}
