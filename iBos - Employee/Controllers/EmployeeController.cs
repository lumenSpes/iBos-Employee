using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace iBos___Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = EmployeeService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Employee Not Found");
            }
        }
        

    }
}
