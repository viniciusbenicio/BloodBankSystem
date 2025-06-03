using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donor.GetAllDonor
{
    public class GetAllDonorsHandlers : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorViewModel>>>
    {
        private readonly BloodBankSystemDBContext _context;
        public GetAllDonorsHandlers(BloodBankSystemDBContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<List<DonorViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donor =  await _context.Donors.Include(d => d.Donations)
                                      .Include(d => d.Address)
                                      .Where(d => !d.IsDeleted).ToListAsync(cancellationToken: cancellationToken);

            var model = donor.Select(DonorViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorViewModel>>.Success(model);
        }
    }
}
