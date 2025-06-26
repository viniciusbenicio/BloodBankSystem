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
            RecurringJob.AddOrUpdate("job-simples", () => Console.WriteLine("Executando..."), "*/15 * * * * *");
            return Ok();
        }
    }
}
