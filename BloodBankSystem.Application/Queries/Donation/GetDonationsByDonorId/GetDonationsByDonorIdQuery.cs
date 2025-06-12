using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetDonationsByDonorId
{
    public class GetDonationsByDonorIdQuery : IRequest<ResultViewModel<DonationByDonorViewModel>>
    {
        public GetDonationsByDonorIdQuery(int donorId)
        {

            DonorId = donorId;

        }
        public int DonorId { get; set; }
    }
}
