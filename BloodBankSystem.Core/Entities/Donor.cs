namespace BloodBankSystem.Core;

public class Donor : BaseEntity
{
    protected Donor() { }
    public Donor(string fullName, string email, DateOnly dateOfBirth, string gender, double weight, string bloodType, string hRFactor, string street, string city, string state, string zipCode) : base()
    {
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        HRFactor = hRFactor;
        Donations = [];
        Address = new Address(street, city, state, zipCode);
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public string Gender { get; private set; }
    public double Weight { get; private set; }
    public string BloodType { get; private set; }
    public string HRFactor { get; private set; }
    public List<Donation> Donations { get; private set; }
    public Address Address { get; private set; }

    public void Update(string fullName, string email, DateOnly dateOfBirth, string gender, double weight, string bloodType, string hrFactor)
    {
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        HRFactor = hrFactor;
    }

    public bool IsEligibleForRegistrationOnly(DateOnly dateOfBirth)
    {
        var age = CalculateAge(dateOfBirth);

        if (age >= 18)
            return true;

        return false;
    }

    public int CalculateAge(DateOnly dateOfBirth)
    {
        var today = DateTime.Now;
        var age = today.Year - dateOfBirth.Year;

        return age;
    }

    public bool CalculateWeight(double weight)
    {
        if (weight > 50)
            return true;

        return false;
    }

    public bool isBelowMinimumDonationAmount(int donationML)
    {
        if (donationML >= 420 && donationML <= 470)
        {
            return true;
        }

        return false;
    }

    public bool isCanDonateGender(DateTime? lastDonation, string gender)
    {
        var today = DateTime.Now.Date;
        var daysLastDonation = (today - lastDonation?.Date)?.Days;

        if (daysLastDonation >= 0)
        {
            if (gender.Equals("Masculino") && daysLastDonation >= 60 || gender.Equals("Feminino") && daysLastDonation >= 90)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        return true;


    }

}
