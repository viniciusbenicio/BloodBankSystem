using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetAllDonation
{
    public class GetAllDonationQuery : IRequest<ResultViewModel<List<DonationViewModel>>>
    {
    }
}
