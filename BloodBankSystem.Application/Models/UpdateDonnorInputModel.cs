namespace BloodBankSystem.Application.Models;

public class UpdateDonnorInputModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public double Weight { get; set; }
    public string BloodType { get; set; }
    public string HRFactor { get; set; }
}
