using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models
{
    public class DonationByDonorViewModel
    {
        public DonationByDonorViewModel(string fullName, string email, string gender, double weight, string bloodType, string hRFactor, List<DonationsViewModel> donations)
        {
            FullName = fullName;
            Email = email;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            HRFactor = hRFactor;
            Donations = donations;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string BloodType { get; set; }
        public string HRFactor { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<DonationsViewModel> Donations { get; }

    }

    public class DonationsViewModel
    {
        public int Id { get; set;}
        public DateTime DonationDate { get; set; }
        public int QuantityML { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
