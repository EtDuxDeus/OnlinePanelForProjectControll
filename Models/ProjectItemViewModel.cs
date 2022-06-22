using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Models.ViewComponents
{
	public class ProjectItemViewModel
	{
		public ProjectItem ProjectItem { get; set; }
		public List<Developer> AssignedDevs { get; set; }
		public SelectList NewDev { get; set; }
	}
}
