using BloodBankSystem.Application.Models;
using BloodBankSystem.Core.Repositores;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donor.GetAllDonor
{
    public class GetAllDonorsHandlers : IRequestHandler<GetAllDonorsQuery, ResultViewModel<List<DonorViewModel>>>
    {
        private readonly IDonorRepository _donorRepository;
        public GetAllDonorsHandlers(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }
        public async Task<ResultViewModel<List<DonorViewModel>>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetAll();

            var model = donor.Select(DonorViewModel.FromEntity).ToList();

            return ResultViewModel<List<DonorViewModel>>.Success(model);
        }
    }
}
