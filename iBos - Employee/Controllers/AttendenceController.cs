using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace iBos___Employee.Controllers
{
    [ApiController]
    [Route("api/[controllr]")]
    public class AttendenceController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = AttendenceService.Get();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Attendence Not Found");
            }
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var data = AttendenceService.Get(id);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Attendence Not Found");
            }
        }
        [HttpPost]
        public IActionResult Create(EmployeeAttendenceDTO attendenceDTO)
        {
            var data = AttendenceService.Create(attendenceDTO);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Please try again");
            }
        }
    }
}
