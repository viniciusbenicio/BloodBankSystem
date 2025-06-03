using BloodBankSystem.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donor.GetAllDonor
{
    public class GetAllDonorsQuery : IRequest<ResultViewModel<List<DonorViewModel>>>
    {

    }
}
