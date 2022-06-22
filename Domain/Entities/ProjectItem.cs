using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Domain.Entities
{
	public class ProjectItem : EntityBase
	{
		[Required(ErrorMessage = "Заповніть назву проекту")]
		[Display(Name ="Назва Проекта")]
		public override string Title { get; set; }

		[Display(Name ="Коротке описання проекту")]
		public override string Subtitle { get; set; }

		[Display(Name = "Повний опис проекту")]
		public override string Text { get; set; }
		[Display(Name ="Дата початку роботи над проектом")]
		[DataType(DataType.Date)]
		public DateTime DateOfStart { get; set; }
		[Display(Name = "Запланована дата закінчення проекту")]
		[DataType(DataType.Date)]
		public DateTime PlannedDateOfEnd { get; set; }

		[Display(Name = "Таски")]
		public List<ProjectTask> ProjectTasks { get; set; }
		[Display(Name = "Назначені розробники")]
		public List<ProjectDevs> Devs { get; set; }

	}
}
