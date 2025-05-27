using BloodBankSystem.Core;
using System.IO;
using System.Reflection.Emit;
using System.Reflection;

namespace BloodBankSystem.Application.Models;

public class CreateDonationInputModel
{
    public int DonorId { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityML { get; set; }
    public Donation ToEntity()
         => new(DonorId, DonationDate, QuantityML);
}
