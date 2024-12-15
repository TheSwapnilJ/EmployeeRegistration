using EmployeeRegistrationCRUD.Models;
using EmployeeRegistrationCRUD.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeService _employeeService;

		public EmployeeController(EmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		
		[HttpGet]
		public async Task<IActionResult> GetAllEmployees()
		{
			var employees = await _employeeService.GetAllEmployeesAsync();
			return Ok(employees);
		}

		
		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetEmployeeById(int id)
		{
			var employee = await _employeeService.GetEmployeeByIdAsync(id);
			if (employee == null)
			{
				return NotFound(new { Message = $"Employee with ID {id} not found." });
			}
			return Ok(employee);
		}

		
		[HttpPost]
		public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var createdEmployee = await _employeeService.AddEmployeeAsync(employee);
			return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
		}

		
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateEmployee(int id, [FromBody] Employee employee)
		{
			if (!ModelState.IsValid || id != employee.Id)
			{
				return BadRequest(ModelState);
			}

			var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
			if (updatedEmployee == null)
			{
				return NotFound(new { Message = $"Employee with ID {id} not found." });
			}

			return Ok(updatedEmployee);
		}

		
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
			if (!isDeleted)
			{
				return NotFound(new { Message = $"Employee with ID {id} not found." });
			}

			return NoContent();
		}
	}
}
