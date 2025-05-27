using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models
{
    public class DonationViewModel
    {
        public DonationViewModel(DateTime donationDate, int quantityML)
        {
            DonationDate = donationDate;
            QuantityML = quantityML;
           
        }

        public DateTime DonationDate { get; private set; }
        public int QuantityML { get; private set; }

        public static DonationViewModel FromEntity(Donation entity)
           => new(entity.DonationDate, entity.QuantityML);
    }
}
