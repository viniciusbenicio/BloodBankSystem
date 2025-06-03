using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donor.GetByIdDonor
{
    public class GetByIdDonorQuery : IRequest<ResultViewModel<DonorViewModel>>
    {
        public GetByIdDonorQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
