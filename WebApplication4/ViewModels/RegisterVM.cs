﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication4.ViewModels
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "first name is requird")]
		public string FName { get; set; }

		[Required(ErrorMessage = "last name is requird")]
		public string LName { get; set; }

		[Required(ErrorMessage = "Email is requird")]
		[EmailAddress(ErrorMessage = "Email invalid")]
		public string Email { get; set; }

		[Required(ErrorMessage = "password is requird")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is requird")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "dosent match")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Agree is requird")]
		public bool isAgree { get; set; }
	}
}