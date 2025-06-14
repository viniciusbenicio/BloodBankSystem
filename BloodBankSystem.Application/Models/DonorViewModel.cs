using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models
{
    public class DonorViewModel
    {
        public DonorViewModel(string fullName, string email, DateOnly dateOfBirth, string gender, double weight, string bloodType, string hRFactor)
        {
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            HRFactor = hRFactor;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string HRFactor { get; private set; }

        public static DonorViewModel FromEntity(Donor entity)
           => new(entity.FullName, entity.Email, entity.DateOfBirth, entity.Gender, entity.Weight, entity.BloodType, entity.HRFactor);
    }
}
