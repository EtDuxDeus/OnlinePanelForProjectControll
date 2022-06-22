using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Models
{
	public class RegisterViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Ім'я")]
		public string UserName { get; set; }
		[Required]
		[Display(Name ="Електронна адреса")]
		public string Email { get; set; }

		[UIHint("password")]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
		[Display(Name = "Телефонний номер")]
		public string PhoneNumber { get; set; }
	}
}
