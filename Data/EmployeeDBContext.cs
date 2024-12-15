using Microsoft.EntityFrameworkCore;
using EmployeeRegistrationCRUD.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeRegistrationCRUD.Data
{
	public class EmployeeDBContext : DbContext
	{
		public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
		{
		}

		
		public DbSet<Employee> Employees { get; set; }

		
	}
}
