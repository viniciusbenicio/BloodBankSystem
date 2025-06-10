using System.Text.Json.Serialization;

namespace BloodBankSystem.Core;

public class Address : BaseEntity
{
    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public int DonorId { get; set; }
    public Donor Donor { get; set; }

    public void Update(string street, string city, string state)
    {
        State = state;
        Street = street;
        City = city;
    }
}
