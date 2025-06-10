using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;
using MediatR;
using System.IO;

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

            var donors = await _donorRepository.GetAll();

            var existDonorEmail = donors.FirstOrDefault(x => x.Email == request.Email);

            if (existDonorEmail is not null)
                return ResultViewModel<int>.Error($"Já existe um Doador Cadastrado com este e-mail: {request.Email}");


            var cepResult = await ICEPService.GetByCepAsync(request.ZipCode);

            if (cepResult != null)
            {
                request.Street = cepResult.logradouro;
                request.City = cepResult.localidade;
                request.State = cepResult.uf;
            }

            await _donorRepository.Add(donor);

            return ResultViewModel<int>.Success(donor.Id);
        }
    }
}
