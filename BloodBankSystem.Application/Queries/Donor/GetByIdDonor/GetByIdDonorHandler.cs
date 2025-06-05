using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Infrastructure.Entities.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBankSystem.Application.Queries.Donor.GetByIdDonor
{
    public class GetByIdDonorHandler : IRequestHandler<GetByIdDonorQuery, ResultViewModel<DonorViewModel>>
    {
        private readonly IDonorRepository _donorRepository;

        public GetByIdDonorHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<ResultViewModel<DonorViewModel>> Handle(GetByIdDonorQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.Id);
               

            if (donor is null)
            {
                return ResultViewModel<DonorViewModel>.Error("Doador não existe.");
            }

            var model = DonorViewModel.FromEntity(donor);

            return ResultViewModel<DonorViewModel>.Success(model);
        }
    }
}
