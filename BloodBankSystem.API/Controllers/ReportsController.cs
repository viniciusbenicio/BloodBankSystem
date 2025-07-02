using BloodBankSystem.Application.Queries.Donation.GetDonationsLast30Days;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("blood-stock-by-type")]
    public async Task<IActionResult> GetBloodStockByTypeReport()
    {
        var query = new GetBloodStockByTypeReportQuery();
        var reportBytes = await _mediator.Send(query);

        return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"BloodDonationsReport_{DateTime.Now.ToString("yyyyMMdd")}.xlsx");
    }

    [HttpGet("donations-last-30-days-with-donors")]
    public async Task<IActionResult> GetDonationsLast30DaysWithDonorsReport()
    {
        var query = new GetDonationsLast30DaysReportQuery();
        var reportBytes = await _mediator.Send(query);

        return File(reportBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"DonationsLast30Days{DateTime.Now.ToString("yyyyMMdd")}.xlsx");
    }
}
