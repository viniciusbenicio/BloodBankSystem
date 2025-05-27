using System.Net;

namespace BloodBankSystem.API.Entities
{
    public class Donor : BaseEntity
    {
        protected Donor() { }
        public Donor(string fullName, string email, DateTime dateOfBirth, string gender, double weight, string bloodType, string hRFactor) : base()
        {
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            HRFactor = hRFactor;

            //Donations = [];
            //Address = new();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public string BloodType { get; private set; }
        public string HRFactor { get; private set; }
        //public List<Donation> Donations { get; private set; }
        //public Address Address { get; private set; }
    }
}
