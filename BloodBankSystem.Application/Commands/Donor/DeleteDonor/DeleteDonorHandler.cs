using BloodBankSystem.Application.Models;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.Donor.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    {
        private readonly BloodBankSystemDBContext _context;
        public DeleteDonorHandler(BloodBankSystemDBContext context)
        {
            _context = context;
        }
        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(d => d.Id == request.Id, cancellationToken: cancellationToken);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe.");
            }

            donor.SetAsDeleted();
            _context.Donors.Update(donor);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}
