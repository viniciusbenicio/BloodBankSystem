using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donation.GetByIdDonation
{
    public class GetByIdDonationHandler : IRequestHandler<GetByIdDonationQuery, ResultViewModel<DonationViewModel>>
    {
        private readonly BloodBankSystemDBContext _context;
        public GetByIdDonationHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<DonationViewModel>> Handle(GetByIdDonationQuery request, CancellationToken cancellationToken)
        {
            var donation = await _context.Donations.FirstOrDefaultAsync(d => d.Id == request.Id && !d.IsDeleted, cancellationToken: cancellationToken);

            if (donation is null)
            {
                return ResultViewModel<DonationViewModel>.Error("Não existe estoque de Sangue");
            }

            var model = DonationViewModel.FromEntity(donation);

            return ResultViewModel<DonationViewModel>.Success(model);
        }
    }
}
