using BloodBankSystem.Application.Job;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankSystem.API.Controllers
{
    [ApiController]
    [Route("api/taks")]
    public class TaksController : ControllerBase
    {
        [HttpGet("recurring")]
        public async Task<IActionResult> Get()
        {
            RecurringJob.AddOrUpdate<NotificationTask>("job-send-notification", jb => jb.Execute(), "*/1 * * * *");
            return Ok();
        }
    }
}
