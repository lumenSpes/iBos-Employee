using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace iBos___Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyReportController : Controller
    {
        [HttpGet]
        public IActionResult GetMonthlyReport()
        {
            var monthlyService = new GetMonthyService(); 
            var data = monthlyService.GetMonthlyReport();

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Record Found!");
            }
        }

    }
}
