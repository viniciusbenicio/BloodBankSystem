using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.CreateDonor
{
    public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly BloodBankSystemDBContext _context;
        public CreateDonorHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }
       

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = request.ToEntity();

            await _context.Donors.AddAsync(donor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
