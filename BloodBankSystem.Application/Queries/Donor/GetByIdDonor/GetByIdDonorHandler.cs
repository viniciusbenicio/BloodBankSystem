using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donor.GetByIdDonor
{
    public class GetByIdDonorHandler : IRequestHandler<GetByIdDonorQuery, ResultViewModel<DonorViewModel>>
    {
        private readonly BloodBankSystemDBContext _context;
        public GetByIdDonorHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel<DonorViewModel>> Handle(GetByIdDonorQuery request, CancellationToken cancellationToken)
        {
            var donor = await _context.Donors
               .Include(d => d.Donations)
               .Include(d => d.Address)
               .FirstOrDefaultAsync(d => d.Id == request.Id && !d.IsDeleted, cancellationToken: cancellationToken);

            if (donor is null)
            {
                return ResultViewModel<DonorViewModel>.Error("Doador não existe.");
            }

            var model = DonorViewModel.FromEntity(donor);

            return ResultViewModel<DonorViewModel>.Success(model);
        }
    }
}
