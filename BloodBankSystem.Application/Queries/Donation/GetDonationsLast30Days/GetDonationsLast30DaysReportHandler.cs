using BloodBankSystem.Core;
using BloodBankSystem.Core.DTOs;
using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;
using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetDonationsLast30Days
{
    public class GetDonationsLast30DaysReportHandler : IRequestHandler<GetDonationsLast30DaysReportQuery, byte[]>
    {
        private readonly IDonationsDonorsRepository _donationsDonorsRepository;
        private readonly IReportGenerator _reportGenerator;

        public GetDonationsLast30DaysReportHandler(IDonationsDonorsRepository donationsDonorsRepository, IReportGenerator reportGenerator)
        {
            _donationsDonorsRepository = donationsDonorsRepository;
            _reportGenerator = reportGenerator;
        }

        public async Task<byte[]> Handle(GetDonationsLast30DaysReportQuery request, CancellationToken cancellationToken)
        {
            var reportData = _donationsDonorsRepository.GetDonationsWithDonorsLast30Days();

            return await _reportGenerator.GenerateReportAsync(reportData);

        }
    }
}
