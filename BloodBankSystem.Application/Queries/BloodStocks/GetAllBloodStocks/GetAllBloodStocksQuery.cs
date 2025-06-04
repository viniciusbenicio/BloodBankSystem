using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetAllDonation
{
    public class GetAllBloodStocksQuery : IRequest<ResultViewModel<List<BloodStockViewModel>>>
    {
    }
}
