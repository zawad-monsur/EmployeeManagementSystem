using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static EmployeeManagementSystem.Controllers.EmployeeController;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(page, pageSize);
            return Ok(employees);
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> SearchEmployees([FromQuery] string name)
        {
            var employees = await _employeeService.SearchEmployeesAsync(name);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> AddEmployee(EmployeeDTO employeeDTO)
        {
            var createdEmployee = await _employeeService.AddEmployeeAsync(employeeDTO);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.EmployeeID }, createdEmployee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.EmployeeID)
            {
                return BadRequest();
            }
            await _employeeService.UpdateEmployeeAsync(employeeDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }


        [HttpGet("department-averages")]
        public async Task<ActionResult<IEnumerable<DepartmentAverageDTO>>> GetDepartmentAverages()
        {
            var averages = await _employeeService.GetDepartmentAverageScoresAsync();
            return Ok(averages);
        }

       
    }
}
