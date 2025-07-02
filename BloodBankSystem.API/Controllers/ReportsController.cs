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
}
