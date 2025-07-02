using MediatR;

namespace BloodBankSystem.Application.Queries.Donation.GetDonationsLast30Days
{
    public class GetDonationsLast30DaysReportQuery : IRequest<byte[]>
    {
        public GetDonationsLast30DaysReportQuery() { }
    }
}
