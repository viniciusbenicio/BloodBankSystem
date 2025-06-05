using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.CreateDonor
{
    public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _donorRepository;
        public CreateDonorHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = request.ToEntity();

            await _donorRepository.Add(donor);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
