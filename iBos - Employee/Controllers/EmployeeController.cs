using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        [HttpPost]
        public IActionResult Create(EmployeeDTO employeeDTO)
        {
            var data = EmployeeService.Create(employeeDTO);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return BadRequest("Please try again");
            }
        }

        [HttpPut("{id}")] // Specify a route parameter to make this action unique
        public IActionResult Update(int id, EmployeeDTO employeeDTO)
        {
            employeeDTO.EmployeeId = id;

            var isSuccess = EmployeeService.Update(employeeDTO);

            if (isSuccess)
            {
                return Ok("Updated :)");
            }
            else
            {
                return BadRequest("Please try again");
            }
        }

        [HttpGet("ThirdHighestSal")] // Specify a unique route
        public IActionResult ThirdHighestSal()
        {
            var data = EmployeeService.Get3rd();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Record Found!");
            }
        }

        [HttpGet("GetOnAbcent")] // Specify a unique route
        public IActionResult GetOnAbcent()
        {
            var data = EmployeeService.GetOnAbsent();
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Record Found!");
            }
        }

        [HttpGet("GetByHierarchy/{id}")] // Specify a unique route with a parameter
        public IActionResult GetByHierarchy(int id)
        {
            var data = EmployeeService.GetEmployeeHierarchy(id);
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
