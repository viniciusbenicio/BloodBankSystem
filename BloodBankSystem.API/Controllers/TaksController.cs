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
            // Usar no futuro para uma possivel dashboard.
            try
            {
                //RecurringJob.AddOrUpdate<NotificationTask>("job-send-notification", jb => jb.Execute(), "*/1 * * * *");

            }catch(Exception ex)
            {
                var msg = ex.Message;
            }
            return Ok();
        }
    }
}
