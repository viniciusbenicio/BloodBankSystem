using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.UpdateDonor
{
    public class UpdateDonorCommand : IRequest<ResultViewModel>
    {
        public UpdateDonorCommand(int id, string fullName, string email, DateOnly dateOfBirth, string gender, double weight, string bloodType, string hRFactor)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            HRFactor = hRFactor;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public string BloodType { get; set; }
        public string HRFactor { get; set; }
    }
}
