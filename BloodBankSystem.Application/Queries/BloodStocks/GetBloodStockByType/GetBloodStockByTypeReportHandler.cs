using BloodBankSystem.Core.DTOs;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;
using MediatR;

namespace BloodBankSystem.Application.Queries.BloodStocks.GetBloodStockByType
{
    public class GetBloodStockByTypeReportHandler : IRequestHandler<GetBloodStockByTypeReportQuery, byte[]>
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly IReportGenerator _reportGenerator;

        public GetBloodStockByTypeReportHandler(IBloodStockRepository bloodStockRepository, IReportGenerator reportGenerator)
        {
            _bloodStockRepository = bloodStockRepository;
            _reportGenerator = reportGenerator;
        }

        public async Task<byte[]> Handle(GetBloodStockByTypeReportQuery request, CancellationToken cancellationToken)
        {
            var donations = _bloodStockRepository.GetTotalBloodStockByType();

            var reportData = donations.Select(d => new BloodStockByTypeDTO
            {
                BloodType = d.BloodType,
                HRFactor = d.HRFactor,
                QuantityMl = d.QuantityMl,
            });

            return await _reportGenerator.GenerateReportAsync(reportData);
        }
    }
}
