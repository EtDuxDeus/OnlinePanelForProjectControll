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
		public ProjectItem ProjectItem { get; set; }
		[Display(Name = "Назва задачі")]
		public string TaskName { get; set; }
		[Display(Name = "Коментар")]
		public string TaskDescription { get; set; }

		[Display(Name = "Виконавець")]
		public string DeveloperId { get; set; }
		public Developer Developer {get;set;}

		[Display(Name = "Кількість виділеного часу")]
		[DataType(DataType.Currency)]
		public int EstimatedTime { get; set; }
		[Display(Name ="Кількість затраченого часу")]
		[DataType(DataType.Currency)]
		public int SpendedTime { get; set; }

		[Display(Name = "Виконано?")]
		public bool isFinished { get; set; }
	}
}
