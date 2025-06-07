using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;
using MediatR;

namespace BloodBankSystem.Application.Commands.Donor.CreateDonor
{
    public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly ICEPService ICEPService;
        public CreateDonorHandler(IDonorRepository donorRepository, ICEPService iCEPService)
        {
            _donorRepository = donorRepository;
            ICEPService = iCEPService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = request.ToEntity();


            var retorno = await ICEPService.GetByCepAsync(request.ZipCode);
            await _donorRepository.Add(donor);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
