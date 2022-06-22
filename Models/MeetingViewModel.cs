using Microsoft.AspNetCore.Mvc.Rendering;
using OnlinePanelForProjectsControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePanelForProjectsControl.Models
{
	public class MeetingViewModel
	{
		public Meeting MeetingRef { get; set; }
		public MultiSelectList SelectedDevs { get; set; }
		public List<string> devsId { get; set; }
	}
}
