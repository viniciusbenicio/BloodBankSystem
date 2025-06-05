using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Commands.Donor.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _donorRepository;
        public UpdateDonorHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.Id);

            if (donor is null)
            {
                return ResultViewModel.Error("Doador não existe");
            }

            donor.Update(request.FullName, request.Email, request.DateOfBirth, request.Gender, request.Weight, request.BloodType, request.HRFactor);
            await _donorRepository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}
