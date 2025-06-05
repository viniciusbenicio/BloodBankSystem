using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.DeleteDonor
{
    public class DeleteDonorHandler : IRequestHandler<DeleteDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _donorRepository;

        public DeleteDonorHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<ResultViewModel> Handle(DeleteDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.Id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe.");
            }

            donor.SetAsDeleted();
            await _donorRepository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}
