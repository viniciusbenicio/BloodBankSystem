using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetByIdDonation
{
    public class GetByIdDonationQuery : IRequest<ResultViewModel<DonationViewModel>>
    {
        public GetByIdDonationQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
