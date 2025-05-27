using BloodBankSystem.Core;
using System.Reflection;

namespace BloodBankSystem.Application.Models
{
    public class CreateDonorAddressInputModel 
    {
        public CreateDonorAddressInputModel(string street, string city, string state, string zipCode, int donorId)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            DonorId = donorId;
        }

        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public int DonorId { get; private set; }
        public Address ToEntity()
         => new(Street, City, State, ZipCode);
    }
}
