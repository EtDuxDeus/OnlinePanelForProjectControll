using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Entities
{
	public class Meeting
	{
		[Required]
		public Guid Id { get; set; }
		[Display(Name ="Назва зустрічі")]
		public string Title { get; set; }
		[Display(Name =("Посилання для зустрічі"))]
		[DataType(DataType.Url)]
		public string Url { get; set; }
		[Display(Name ="Дата проведення зустрічі")]
		[DataType(DataType.DateTime)]
		public DateTime DateOfMeet { get; set; }
		[Display(Name ="Опис зустрічі")]
		public string Description { get; set; }
		public List<Developer> Devs { get; set; }
	}
}
