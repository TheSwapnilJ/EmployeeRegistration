using EmployeeRegistrationCRUD.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Services
{
	public interface EmployeeService
	{
		Task<IEnumerable<Employee>> GetAllEmployeesAsync();
		Task<Employee> GetEmployeeByIdAsync(int id);
		Task<Employee> AddEmployeeAsync(Employee employee);
		Task<Employee> UpdateEmployeeAsync(Employee employee);
		Task<bool> DeleteEmployeeAsync(int id);
	}
}
