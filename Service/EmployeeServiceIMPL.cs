using EmployeeRegistrationCRUD.Models;
using EmployeeRegistrationCRUD.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Services
{
	public class EmployeeServiceImpl : EmployeeService
	{
		private readonly EmployeeDBContext _context;

		public EmployeeServiceImpl(EmployeeDBContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
		{
			return await _context.Employees.ToListAsync();
		}

		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task<Employee> AddEmployeeAsync(Employee employee)
		{
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
			return employee;
		}

		public async Task<Employee> UpdateEmployeeAsync(Employee employee)
		{
			var existingEmployee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == employee.Id);
			if (existingEmployee == null)
			{
				return null; 
			}

			
			existingEmployee.FirstName = employee.FirstName;
			existingEmployee.LastName = employee.LastName;
			existingEmployee.Email = employee.Email;
			existingEmployee.DateOfBirth = employee.DateOfBirth;
			existingEmployee.PhoneNumber = employee.PhoneNumber;
			existingEmployee.Address = employee.Address;
			existingEmployee.Position = employee.Position;
			existingEmployee.Department = employee.Department;
			existingEmployee.Salary = employee.Salary;
			existingEmployee.UpdatedAt = System.DateTime.UtcNow;

			await _context.SaveChangesAsync();
			return existingEmployee;
		}

		public async Task<bool> DeleteEmployeeAsync(int id)
		{
			var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
			if (employee == null)
			{
				return false; 
			}

			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
