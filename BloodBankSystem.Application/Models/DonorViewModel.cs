using BloodBankSystem.Core;

namespace BloodBankSystem.Application.Models
{
    public class DonorViewModel
    {
        public DonorViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }

        public static DonorViewModel FromEntity(Donor entity)
           => new(entity.FullName, entity.Email);
    }
}
