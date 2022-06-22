using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Models
{
	public class ProjectTaskViewModel
	{
		public ProjectTask ProjectTaskReference { get; set; }
		public SelectList SelectedDev { get; set; }
	}
}
