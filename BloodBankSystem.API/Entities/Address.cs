namespace BloodBankSystem.API.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int DonorId { get; set; }  
        public Donor Donor { get; set; }
    }
}
