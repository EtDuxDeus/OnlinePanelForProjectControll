using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Entities
{
	public class ProjectTask
	{
		[Required]
		public Guid TaskID { get; set; }

		[Display(Name = "Проект")]
		public Guid ProjectId { get; set; }
		public ProjectItem ProjectItem {get;set;}
		[Display(Name = "Назва задачі")]
		public string TaskName { get; set; }
		[Display(Name = "Опис задачі")]
		public string TaskDescription { get; set; }

		[Display(Name = "Дата початку роботи над задачею")]
		[DataType(DataType.Date)]
		public DateTime DateOfStart { get;set; }
		
		[Display(Name = "Дата Завершення роботи над задачею")]
		[DataType(DataType.Date)]
		public DateTime DateOfEnd { get;set; }

		[Display(Name = "Виконано?")]
		public bool isFinished { get; set; }
	}
}
