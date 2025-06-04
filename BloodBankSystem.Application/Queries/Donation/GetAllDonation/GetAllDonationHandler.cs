using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donation.GetAllDonation
{
    public class GetAllDonationHandler : IRequestHandler<GetAllDonationQuery, ResultViewModel<List<DonationViewModel>>>
    {
        private readonly BloodBankSystemDBContext _context;
        public GetAllDonationHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<DonationViewModel>>> Handle(GetAllDonationQuery request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.Where(d => !d.IsDeleted).ToListAsync(cancellationToken: cancellationToken);

            var model = donation.Select(DonationViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonationViewModel>>.Success(model);
        }
    }
}
