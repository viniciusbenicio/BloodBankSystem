using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.CreateDonor
{
    public class CreateDonorCommand : IRequest<ResultViewModel<int>>
    {
        public CreateDonorCommand(string fullName, string email, DateTime dateOfBirth, string gender, double weight, string bloodType, string hRFactor, string zipCode)
        {
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            HRFactor = hRFactor;
            ZipCode = zipCode;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string BloodType { get; set; }
        public string HRFactor { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public BloodBankSystem.Core.Donor ToEntity()
         => new(FullName, Email, DateOfBirth, Gender, Weight, BloodType, HRFactor, Street, City, State, ZipCode);

    }
}
