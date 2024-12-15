using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegistrationCRUD.Models
{
	public class Employee
	{
		[Key] 
		public int Id { get; set; }

		[Required(ErrorMessage = "First Name is required")]
		[StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
		public string ? FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required")]
		[StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
		public string ? LastName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Date of Birth is required")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Phone Number is required")]
		[Phone(ErrorMessage = "Invalid Phone Number")]
		public string? PhoneNumber { get; set; }

		[StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
		public string? Address { get; set; }

		[Required(ErrorMessage = "Position is required")]
		[StringLength(50, ErrorMessage = "Position cannot exceed 50 characters")]
		public string? Position { get; set; }

		[Required(ErrorMessage = "Department is required")]
		[StringLength(50, ErrorMessage = "Department cannot exceed 50 characters")]
		public string? Department { get; set; }

		[DataType(DataType.Currency)]
		[Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
		public decimal Salary { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	}
}
