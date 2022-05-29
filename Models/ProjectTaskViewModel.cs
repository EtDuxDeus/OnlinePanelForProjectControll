using Microsoft.AspNetCore.Mvc;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Models
{
	public class ProjectTaskViewModel
	{
		public ProjectTask[] CurrentProjectTasks { get; set; }
	}
}
